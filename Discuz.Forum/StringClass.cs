using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Discuz.Forum
{
    public class StringClass
    {
        /// <summary>
        /// 是否为有效域
        /// </summary>
        /// <param name="host">域名</param>
        /// <returns></returns>
        public static bool IsValidDomain(string host)
        {
            if (host.IndexOf(".") == -1)
                return false;

            return new Regex(@"^\d+$").IsMatch(host.Replace(".", string.Empty)) ? false : true;
        }
    }
}
