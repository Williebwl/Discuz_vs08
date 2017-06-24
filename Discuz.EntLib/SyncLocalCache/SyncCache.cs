using Discuz.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading;

namespace Discuz.EntLib
{
    /// <summary>
    /// 同步缓存类
    /// </summary>
    public class SyncCache
    {
        /// <summary>
        /// 除本站之外的负载均衡站点列表
        /// </summary>
        static List<string> syncCacheUrlList = null;
        static LoadBalanceConfigInfo loadBalanceConfigInfo = LoadBalanceConfigs.GetConfig();

        static SyncCache()
        {
            syncCacheUrlList = new List<string>();
            syncCacheUrlList.AddRange(loadBalanceConfigInfo.SiteUrl.Replace("tools/", "tools/SyncLocalCache.aspx").Split(','));
            int port = HttpContext.Current.Request.Url.Port;

            string localUrl = string.Format("{0}://{1}{2}{3}",
                HttpContext.Current.Request.Url.Scheme,
                HttpContext.Current.Request.Url.Host,
                (port == 80 || port == 0) ? string.Empty : ":" + port,
                BaseConfigs.GetForumPath
                );

            Predicate<string> matchUrl = new Predicate<string>
       (
           delegate (string webUrl)
           {
               return webUrl.IndexOf(localUrl) >= 0; //移除本地站点链接，因为当前站点缓存已被移除。
           }
       );

            syncCacheUrlList.RemoveAll(matchUrl);
        }
        /// <summary>
        /// 同步远程缓存信息
        /// </summary>
        /// <param name="objId"></param>
        public static void SyncRemoteCache(string cacheKey)
        {
            foreach (string webSite in syncCacheUrlList)
            {
                string url = string.Format("{0}?cacheKey={1}&passKey={2}",
                                      webSite,
                                      cacheKey,
                                      Discuz.Common.Utils.UrlEncode(Discuz.Common.DES.Encode(cacheKey, loadBalanceConfigInfo.AuthCode)));

                //使用一个线程来发送相应的同步数据请求到各个分布式应用上
                ThreadSyncRemoteCache src = new ThreadSyncRemoteCache(url);

                new Thread(new ThreadStart(src.Send)).Start();
            }
        }
    }
}
