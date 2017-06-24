using System.Collections;
using Discuz.Config;
using Discuz.Common;

using ServiceStack.Redis;

namespace Discuz.EntLib
{
    /// <summary>
    /// Redis管理操作类
    /// </summary>
    public sealed class RedisManager
    {
        /// <summary>
        /// redis配置文件信息
        /// </summary>
        private static RedisConfigInfo redisConfigInfo = RedisConfigs.GetConfig();

        /// <summary>
        /// 静态构造方法，初始化链接池管理对象
        /// </summary>
        static RedisManager()
        {
            CreateManager();
        }


        /// <summary>
        /// 创建链接池管理对象
        /// </summary>
        private static PooledRedisClientManager CreateManager()
        {
            string[] writeServerList = Utils.SplitString(redisConfigInfo.WriteServerList, ",");
            string[] readServerList = Utils.SplitString(redisConfigInfo.ReadServerList, ",");

            PooledRedisClientManager prcm = new PooledRedisClientManager(readServerList, writeServerList,
                             new RedisClientManagerConfig
                             {
                                 MaxWritePoolSize = redisConfigInfo.MaxWritePoolSize,
                                 MaxReadPoolSize = redisConfigInfo.MaxReadPoolSize,
                                 AutoStart = redisConfigInfo.AutoStart,
                             });
            return prcm;
        }

        /// <summary>
        /// 客户端缓存操作对象
        /// </summary>
        public static IRedisClient GetClient()
        {
            //if (prcm == null)
            //    CreateManager();

            //return prcm.GetClient();

            IRedisClient redisClient = CreateManager().GetClient();
            return redisClient;
        }
    }
}