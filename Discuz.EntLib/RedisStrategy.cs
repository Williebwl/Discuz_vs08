using System;
using System.Collections.Generic;
using System.Text;
using Discuz.Cache;
using Discuz.Config;
using ServiceStack.Redis;
using ServiceStack.Redis.Support;

namespace Discuz.EntLib
{
    /// <summary>
    /// 企业级Redis缓存策略类
    /// </summary>
    public class RedisStrategy : DefaultCacheStrategy
    {
        /// <summary>
        /// 添加指定ID的对象
        /// </summary>
        /// <param name="objId"></param>
        /// <param name="o"></param>
        public override void AddObject(string objId, object o)
        {
            if (!objId.StartsWith("/Forum/ShowTopic/"))
                base.AddObject(objId, o, LocalCacheTime);

            using (IRedisClient Redis = RedisManager.GetClient())
            {
                Redis.Set<byte[]>(objId, new ObjectSerializer().Serialize(o));
            }
        }

        /// <summary>
        /// 加入当前对象到缓存中
        /// </summary>
        /// <param name="objId">对象的键值</param>
        /// <param name="o">缓存的对象</param>
        /// <param name="o">到期时间,单位:秒</param>
        public override void AddObject(string objId, object o, int expire)
        {
            //凡是以"/Forum/ShowTopic/"为前缀不添加到本地缓存中，现类似键值包括: "/Forum/ShowTopic/Tag/{topicid}/" , "/Forum/ShowTopic/TopList/{fid}"
            if (!objId.StartsWith("/Forum/ShowTopic/"))
                base.AddObject(objId, o, expire);

            using (IRedisClient Redis = RedisManager.GetClient())
            {
                //永不过期
                if (expire == 0)
                    Redis.Set<byte[]>(objId, new ObjectSerializer().Serialize(o));
                else
                    Redis.Set<byte[]>(objId, new ObjectSerializer().Serialize(o), DateTime.Now.AddSeconds(expire));
            }
        }


        /// <summary>
        /// 移除指定ID的对象
        /// </summary>
        /// <param name="objId"></param>
        public override void RemoveObject(string objId)
        {
            //先移除本地cached，然后再移除memcached中的相应数据
            base.RemoveObject(objId);
            using (IRedisClient Redis = RedisManager.GetClient())
            {
                Redis.Remove(objId);
            }
            Discuz.EntLib.SyncCache.SyncRemoteCache(objId);
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
                using (IRedisClient Redis = RedisManager.GetClient())
                {
                    obj = new ObjectSerializer().Deserialize(Redis.Get<byte[]>(objId));

                    if (obj != null && !objId.StartsWith("/Forum/ShowTopic/"))//对ShowTopic页面缓存数据不放到本地缓存
                    {
                        if (objId.StartsWith("/Forum/ShowTopicGuestCachePage/"))//对游客缓存页面ShowTopic数据缓存设置有效时间
                            base.TimeOut = GeneralConfigs.GetConfig().Guestcachepagetimeout * 60;
                        if (objId.StartsWith("/Forum/ShowForumGuestCachePage/"))//对游客缓存页面ShowTopic数据缓存设置有效时间
                            base.TimeOut = RedisConfigs.GetConfig().CacheShowForumCacheTime * 60;
                        else
                            base.TimeOut = LocalCacheTime;

                        base.AddObject(objId, obj, TimeOut);
                    }
                }
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
        //    object obj = this.RetrieveObject(cache_key);
        //    if (obj == null)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}
        /// <summary>
        /// 到期时间,单位:秒
        /// </summary>
        public override int TimeOut
        {
            get
            {
                return 3600;
            }
        }

        /// <summary>
        /// 本地缓存到期时间,单位:秒
        /// </summary>
        public int LocalCacheTime
        {
            get
            {
                return RedisConfigs.GetConfig().LocalCacheTime;
            }
        }

        /// <summary>
        /// 清空的有缓存数据
        /// </summary>
        public override void FlushAll()
        {
            base.FlushAll();
            using (IRedisClient Redis = RedisManager.GetClient())
            {
                Redis.FlushAll();
            }
        }
    }
}
