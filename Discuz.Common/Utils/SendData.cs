using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Security.Cryptography;

namespace Discuz.Common
{
    public class SendData
    {
        #region "字段属性"
        private static SendData _intsance;

        public static SendData Intsance
        {
            get { return SendData._intsance; }
            set { SendData._intsance = value; }
        }
        #endregion

        #region "构造函数"
        public SendData()
        {

        }

        static SendData()
        {
            _intsance = new SendData();
        }
        #endregion

        #region "方法事件"
        /// <summary>
        /// 发送请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="strencoding">编码格式</param>
        /// <returns>响应报文</returns>
        public string SendRequest(string url, string strencoding, string strPost)
        {
            DownloadFile _downloadfile = new DownloadFile();
            _downloadfile.Url = url;
            _downloadfile.StrEncoding = strencoding;
            _downloadfile.StrPost = strPost;
            _downloadfile.Start();
            return _downloadfile.HtmlText;
        }
        /// <summary>
        /// MD5加密程序（32位小写）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string md5(string str)
        {
            byte[] result = Encoding.Default.GetBytes(str);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            String md = BitConverter.ToString(output).Replace("-", "");
            return md.ToLower();
        }
        #endregion
    }
}
