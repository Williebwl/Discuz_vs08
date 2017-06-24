using Discuz.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Discuz.EntLib
{
    /// <summary>
    /// 多线程更新远程缓存
    /// </summary>
    public class ThreadSyncRemoteCache
    {
        public string _url;
        public ThreadSyncRemoteCache(string url)
        {
            _url = url;
        }
        public void Send()
        {
            try
            {
                //设置循环三次，如果某一次更新成功("OK")，则跳出循环
                for (int i = 0; i < 3; i++)
                {
                    string result = SendData.Intsance.SendRequest(_url, "utf-8", string.Empty);
                    if (!string.IsNullOrEmpty(result) && result.Equals("ok"))
                    {
                        break;
                    }
                    else
                    {
                        Thread.Sleep(5000);//如果更新不成功，则暂停5秒后再次更新
                    }
                }
            }
            catch
            {


            }
            finally
            {
                if (Thread.CurrentThread.IsAlive)
                    Thread.CurrentThread.Abort();
            }
        }
    }
}
