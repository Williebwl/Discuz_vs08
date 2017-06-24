using Discuz.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace Discuz.EntLib
{
    public class WeightedRoundRobinScheduling : ILoadBalanceScheduling
    {
        private static object lockHelper = new object();
        /// <summary>
        /// 快照的权重列表
        /// </summary>
        static List<int> snapWeightList = new List<int>();
        /// <summary>
        /// 当前的快照索引和权重信息
        /// </summary>
        static int curentSnapIndex, currentWeight;
        /// <summary>
        /// 快照权重列表中最大的权重值和最大公约数
        /// </summary>
        static int maxWeight, gcd;

        static WeightedRoundRobinScheduling()
        {
            curentSnapIndex = -1;
            currentWeight = 0;

            snapWeightList = GetSnapWeightList();
            maxWeight = GetMaxWeight(snapWeightList);
            gcd = GCD(snapWeightList);
        }

        /// <summary>
        /// 获取应用当前负载均衡调度算法下的快照链接信息
        /// </summary>
        /// <returns></returns>
        public DbSnapInfo GetConnectDbSnap()
        {
            lock (lockHelper)
            {
                DbSnapInfo current = RoundRobinScheduling();
                if (current != null)
                    return current;
                else
                    return DbSnapConfigs.GetEnableSnapList()[0];
            }
        }

        /// <summary>
        /// 获取快照权重的列表
        /// </summary>
        /// <returns></returns>
        static List<int> GetSnapWeightList()
        {
            List<int> snapWeightList = new List<int>();

            foreach (DbSnapInfo dbSnapInfo in DbSnapConfigs.GetEnableSnapList())
            {
                snapWeightList.Add(dbSnapInfo.Weight);
            }
            return snapWeightList;
        }

        /// <summary>
        /// 权重轮询调度算法
        /// </summary>
        static DbSnapInfo RoundRobinScheduling()
        {
            while (true)
            {
                curentSnapIndex = (curentSnapIndex + 1) % DbSnapConfigs.GetEnableSnapList().Count;
                if (curentSnapIndex == 0)
                {
                    currentWeight = currentWeight - gcd;
                    if (currentWeight <= 0)
                    {
                        currentWeight = maxWeight;
                        if (currentWeight == 0)
                            return null;
                    }
                }
                if (DbSnapConfigs.GetEnableSnapList()[curentSnapIndex].Weight >= currentWeight)
                    return DbSnapConfigs.GetEnableSnapList()[curentSnapIndex];
            }
        }

        /// <summary>
        /// 获取最大权重
        /// </summary>
        /// <param name="snapList"></param>
        /// <returns></returns>
        static int GetMaxWeight(List<int> snapWeightList)
        {
            int maxWeight = 0;
            foreach (int snapWeight in snapWeightList)
            {
                if (maxWeight < snapWeight)
                    maxWeight = snapWeight;
            }
            return maxWeight;
        }

        /// <summary>
        /// 获取权重的最大公约数
        /// </summary>
        /// <returns></returns>
        static int GCD(List<int> snapWeightList)
        {
            // 排序，得到数字中最小的一个 
            snapWeightList.Sort(new WeightCompare());
            int minNum = snapWeightList[0];

            // 最大公约数肯定大于等于1，且小于等于最小的那个数。 
            // 依次整除，如果余数全部为0说明是一个约数，直到打出最大的那个约数 
            int gcd = 1;
            for (int i = 1; i <= minNum; i++)
            {
                bool isFound = true;
                foreach (int snapWeight in snapWeightList)
                {
                    if (snapWeight % i != 0)
                    {
                        isFound = false;
                        break;
                    }
                }
                if (isFound)
                    gcd = i;
            }
            return gcd;
        }

        /// <summary>
        /// 实现IComparer接口,用于对数字列表进行排序
        /// </summary>  
        private class WeightCompare : System.Collections.Generic.IComparer<int>
        {
            public int Compare(int weightA, int weightB)
            {
                return weightA - weightB;
            }
        }
    }
}
