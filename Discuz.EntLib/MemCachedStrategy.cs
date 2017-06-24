using Discuz.Cache;
using Discuz.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace Discuz.EntLib
{
    /// <summary>
    /// 企业级MemCache缓存策略类,只能使用一个web园程序
    /// </summary>
    public class MemCachedStrategy : DefaultCacheStrategy
    {
        /// <summary>
        /// 添加指定ID的对象
        /// </summary>
        /// <param name="objId"></param>
        /// <param name="o"></param>
        public override void AddObject(string objId, object o)
        {
            //先向本地cached加入，然后再加到memcached
            this.RemoveObject(objId);
            base.AddObject(objId, o);
            if (TimeOut > 0)
            {
                MemCachedManager.CacheClient.Set(objId, o, System.DateTime.Now.AddMinutes(TimeOut));
            }
            else
            {
                MemCachedManager.CacheClient.Set(objId, o);
            }
        }

        /// <summary>
        /// 添加指定ID的对象(关联指定文件组)
        /// </summary>
        /// <param name="objId"></param>
        /// <param name="o"></param>
        /// <param name="files"></param>
        public override void AddObjectWithFileChange(string objId, object o, string[] files)
        {
            ;
        }

        /// <summary>
        /// 添加指定ID的对象(关联指定键值组)
        /// </summary>
        /// <param name="objId"></param>
        /// <param name="o"></param>
        /// <param name="dependKey"></param>
        public override void AddObjectWithDepend(string objId, object o, string[] dependKey)
        {
            ;
        }

        /// <summary>
        /// 移除指定ID的对象
        /// </summary>
        /// <param name="objId"></param>
        public override void RemoveObject(string objId)
        {
            //先移除本地cached，然后再移除memcached中的相应数据
            if (base.RetrieveObject(objId) != null)
                base.RemoveObject(objId);

            if (MemCachedManager.CacheClient.KeyExists(objId))
                MemCachedManager.CacheClient.Delete(objId);

            Discuz.EntLib.SyncCache.SyncRemoteCache(objId);//通知其它分布式应用
        }
        /// <summary>
        /// 返回指定ID的对象
        /// </summary>
        /// <param name="objId"></param>
        /// <returns></returns>
        public override object RetrieveObject(string objId)
        {
            object obj = base.RetrieveObject(objId);
            if (obj == null)
            {
                obj = MemCachedManager.CacheClient.Get(objId);
                if (obj != null)
                    base.AddObject(objId, obj);
            }
            return obj;
        }
        ///// <summary>
        ///// 是否存在
        ///// </summary>
        ///// <param name="cache_key"></param>
        ///// <returns></returns>
        //public override bool Exists(string cache_key)
        //{
        //    return MemCachedManager.CacheClient.KeyExists(cache_key);
        //}
        public override void AddObject(string objId, object o, int expire)
        {
            throw new NotImplementedException();
        }

        public override void FlushAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 到期时间
        /// </summary>
        public override int TimeOut
        {
            get
            {
                return MemCachedConfigs.GetConfig().LocalCacheTime;
            }
        }
    }
}
