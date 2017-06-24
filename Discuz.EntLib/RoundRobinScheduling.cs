using Discuz.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace Discuz.EntLib
{
    /// <summary>
    /// 轮叫调度（Round Robin Scheduling）算法
    /// </summary>
    public class RoundRobinScheduling : ILoadBalanceScheduling
    {
        private static object lockHelper = new object();
        /// <summary>
        /// 当前的快照索引和权重信息
        /// </summary>
        static int curentSnapIndex = 0;

        static RoundRobinScheduling()
        { }

        public DbSnapInfo GetConnectDbSnap()
        {
            lock (lockHelper)
            {
                if (curentSnapIndex >= DbSnapConfigs.GetEnableSnapList().Count)
                    curentSnapIndex = (curentSnapIndex) % DbSnapConfigs.GetEnableSnapList().Count;

                return DbSnapConfigs.GetEnableSnapList()[curentSnapIndex++];
            }
        }
    }
}
