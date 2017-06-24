﻿using System.Collections;
using Discuz.Config;
using Discuz.Common;
//using Memcached.ClientLibrary;
using Discuz.Cache;
namespace Discuz.EntLib
{
    /// <summary>

    /// MemCache管理操作类

    /// </summary>

    public sealed class MemCachedManager

    {

        private static MemcachedClient mc = null;



        private static SockIOPool pool = null;



        private static MemCachedConfigInfo memCachedConfigInfo = MemCachedConfigs.GetConfig();



        private static string[] serverList = null;



        static MemCachedManager()

        {

            CreateManager();

        }
        private static void CreateManager()

        {

            serverList = Utils.SplitString(memCachedConfigInfo.ServerList, "\r\n");


            //初始化池
            pool = SockIOPool.GetInstance(memCachedConfigInfo.PoolName);
            //设置服务器列表
            pool.SetServers(serverList);
            //初始化链接数
            pool.InitConnections = memCachedConfigInfo.IntConnections;
            //最少链接数
            pool.MinConnections = memCachedConfigInfo.MinConnections;
            //最大连接数
            pool.MaxConnections = memCachedConfigInfo.MaxConnections;
            //Socket链接超时时间
            pool.SocketConnectTimeout = memCachedConfigInfo.SocketConnectTimeout;
            // Socket超时时间
            pool.SocketTimeout = memCachedConfigInfo.SocketTimeout;
            //维护线程休息时间
            pool.MaintenanceSleep = memCachedConfigInfo.MaintenanceSleep;
            //失效转移(一种备份操作模式)
            pool.Failover = memCachedConfigInfo.FailOver;
            //是否用nagle算法启动socket
            pool.Nagle = memCachedConfigInfo.Nagle;

            //pool.HashingAlgorithm = (SockIOPool.HashingAlgorithm)Discuz.Config.HashingAlgorithm.NewCompatibleHash;

            pool.Initialize();


            mc = new MemcachedClient();
            //链接池名称
            mc.PoolName = memCachedConfigInfo.PoolName;
            //是否启用压缩数据：如果启用了压缩，数据压缩长于门槛的数据将被储存在压缩的形式
            mc.EnableCompression = false;

        }

        #region 缓存服务器地址列表
        /// <summary>
        /// 缓存服务器地址列表
        /// </summary>
        public static string[] ServerList

        {

            set
            {

                if (value != null)

                    serverList = value;

            }

            get { return serverList; }

        }

        #endregion

        #region 客户端缓存操作对象
        /// <summary>
        /// 客户端缓存操作对象
        /// </summary>
        public static MemcachedClient CacheClient
        {
            get
            {
                if (mc == null)

                    CreateManager();

                return mc;
            }

        }
        #endregion

        #region 释放SockIOPool
        public static void Dispose()
        {
            if (pool != null)

                pool.Shutdown();
        }
        #endregion

        #region 获取当前缓存键值所存储在的服务器
        /// <summary>
        /// 获取当前缓存键值所存储在的服务器
        /// </summary>
        /// <param name="key">当前缓存键</param>
        /// <returns>当前缓存键值所存储在的服务器</returns>
        public static string GetSocketHost(string key)
        {
            string hostName = "";
            SockIO sock = null;
            try
            {
                sock = SockIOPool.GetInstance(memCachedConfigInfo.PoolName).GetSock(key);
                if (sock != null)
                {
                    hostName = sock.Host;
                }
            }
            finally
            {
                if (sock != null)
                    sock.Close();
            }
            return hostName;
        }
        #endregion

        #region  获取有效的服务器地址
        /// <summary>
        /// 获取有效的服务器地址
        /// </summary>
        /// <returns>有效的服务器地</returns>
        public static string[] GetConnectedSocketHost()
        {
            SockIO sock = null;
            string connectedHost = null;
            foreach (string hostName in serverList)
            {
                if (!Discuz.Common.Utils.StrIsNullOrEmpty(hostName))
                {
                    try
                    {
                        sock = SockIOPool.GetInstance(memCachedConfigInfo.PoolName).GetConnection(hostName);
                        if (sock != null)
                        {
                            connectedHost = Discuz.Common.Utils.MergeString(hostName, connectedHost);
                        }
                    }
                    finally
                    {
                        if (sock != null)
                            sock.Close();
                    }
                }
            }
            return Discuz.Common.Utils.SplitString(connectedHost, ",");
        }
        #endregion

        #region 获取服务器端缓存的数据信息
        /// <summary>
        /// 获取服务器端缓存的数据信息
        /// </summary>
        /// <returns>返回信息</returns>
        public static ArrayList GetStats()
        {
            ArrayList arrayList = new ArrayList();
            foreach (string server in serverList)
            {
                arrayList.Add(server);
            }
            return GetStats(arrayList, Stats.Default, null);
        }
        #endregion

        #region 获取服务器端缓存的数据信息
        /// <summary>
        /// 获取服务器端缓存的数据信息
        /// </summary>
        /// <param name="serverArrayList">要访问的服务列表</param>
        /// <returns>返回信息</returns>
        public static ArrayList GetStats(ArrayList serverArrayList, Stats statsCommand, string param)
        {
            ArrayList statsArray = new ArrayList();
            param = Utils.StrIsNullOrEmpty(param) ? "" : param.Trim().ToLower();

            string commandstr = "stats";
            //转换stats命令参数
            switch (statsCommand)
            {
                case Stats.Reset: { commandstr = "stats reset"; break; }
                case Stats.Malloc: { commandstr = "stats malloc"; break; }
                case Stats.Maps: { commandstr = "stats maps"; break; }
                case Stats.Sizes: { commandstr = "stats sizes"; break; }
                case Stats.Slabs: { commandstr = "stats slabs"; break; }
                case Stats.Items: { commandstr = "stats"; break; }
                case Stats.CachedDump:
                    {
                        string[] statsparams = Utils.SplitString(param, " ");
                        if (statsparams.Length == 2)
                            if (Utils.IsNumericArray(statsparams))
                                commandstr = "stats cachedump  " + param;

                        break;
                    }
                case Stats.Detail:
                    {
                        if (string.Equals(param, "on") || string.Equals(param, "off") || string.Equals(param, "dump"))
                            commandstr = "stats detail " + param.Trim();

                        break;
                    }
                default: { commandstr = "stats"; break; }
            }
            //加载返回值
            Hashtable stats = MemCachedManager.CacheClient.Stats(serverArrayList, commandstr);
            foreach (string key in stats.Keys)
            {
                statsArray.Add(key);
                Hashtable values = (Hashtable)stats[key];
                foreach (string key2 in values.Keys)
                {
                    statsArray.Add(key2 + ":" + values[key2]);
                }
            }
            return statsArray;
        }
        #endregion

        #region Stats命令行参数
        /// <summary>
        /// Stats命令行参数
        /// </summary>
        public enum Stats
        {
            /// <summary>
            /// stats : 显示服务器信息, 统计数据等
            /// </summary>
            Default = 0,
            /// <summary>
            /// stats reset : 清空统计数据
            /// </summary>
            Reset = 1,
            /// <summary>
            /// stats malloc : 显示内存分配数据
            /// </summary>
            Malloc = 2,
            /// <summary>
            /// stats maps : 显示"/proc/self/maps"数据
            /// </summary>
            Maps = 3,
            /// <summary>
            /// stats sizes
            /// </summary>
            Sizes = 4,
            /// <summary>
            /// stats slabs : 显示各个slab的信息,包括chunk的大小,数目,使用情况等
            /// </summary>
            Slabs = 5,
            /// <summary>
            /// stats items : 显示各个slab中item的数目和最老item的年龄(最后一次访问距离现在的秒数)
            /// </summary>
            Items = 6,
            /// <summary>
            /// stats cachedump slab_id limit_num : 显示某个slab中的前 limit_num 个 key 列表
            /// </summary>
            CachedDump = 7,
            /// <summary>
            /// stats detail [on|off|dump] : 设置或者显示详细操作记录   on:打开详细操作记录  off:关闭详细操作记录 dump: 显示详细操作记录(每一个键值get,set,hit,del的次数)
            /// </summary>
            Detail = 8
        }
        #endregion 
    }
}