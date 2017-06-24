using System;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;


namespace Discuz.Common
{
    /// <summary>
    /// 下载网页或文件处理类
    /// </summary>
    public class DownloadFile
    {
        #region " 成员属性 "
        private string _url;
        /// <summary>
        /// 下载链接
        /// </summary>
        public string Url
        {
            get { return _url; }
            set
            {
                _url = value.Replace("\\", "/");
                if (!_url.StartsWith("http:", StringComparison.CurrentCultureIgnoreCase))
                {
                    _url = "http://" + _url;
                }
                while (_url.LastIndexOf("//") > 5)
                {
                    _url = _url.Remove(_url.LastIndexOf("//"), 1);
                }
            }
        }

        /// <summary>
        /// 请求URI
        /// </summary>
        public Uri RequestUri { get; private set; }
        /// <summary>
        /// 返回URI
        /// </summary>
        public Uri ResponseUri { get; private set; }

        private byte[] _getData;
        /// <summary>
        /// 下载数据包
        /// </summary>
        public byte[] GetData
        {
            get { return _getData; }
            set { _getData = value; }
        }

        private string _htmlText = string.Empty;
        /// <summary>
        /// 下载网页文本
        /// </summary>
        public string HtmlText
        {
            get { return _htmlText; }
            protected set { _htmlText = AnalyticalReplace(value); }
        }

        private string _cookie;
        /// <summary>
        ///Cookie数据
        /// </summary>
        public string Cookie
        {
            get { return _cookie; }
            set { _cookie = value; }
        }
        private CookieContainer _cookieContainer;
        /// <summary>
        /// Cookie集合
        /// </summary>
        public CookieContainer CookieContainer
        {
            get { return _cookieContainer; }
            set { _cookieContainer = value; }
        }

        private string _strPost;
        /// <summary>
        /// Post字符串
        /// </summary>
        public string StrPost
        {
            get { return _strPost; }
            set { _strPost = value; }
        }

        private byte[] _postdata;
        /// <summary>
        /// Post数据
        /// </summary>
        public byte[] PostData
        {
            get { return _postdata; }
            set { _postdata = value; }
        }

        private int _trycount = 3;
        /// <summary>
        /// 尝试页面请求次数,默认为三次
        /// </summary>
        public int TryCount
        {
            get
            {
                return _trycount;
            }
            set
            {
                _trycount = value;
            }
        }
        private int _timeout = 10000;
        /// <summary>
        /// 请求超时时间
        /// </summary>
        public int Timeout
        {
            get { return _timeout; }
            set { _timeout = value; }
        }
        private string _userAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.2; .NET CLR 1.1.4322; .NET CLR 2.0.50727; InfoPath.1) Web-Sniffer/1.0.24";
        /// <summary>
        /// 模拟浏览器及操作系统信息
        /// </summary>
        public string UserAgent
        {
            get { return _userAgent; }
            set { _userAgent = value; }
        }

        private Encoding _encoding = Encoding.Default;
        /// <summary>
        /// 字符编码
        /// </summary>
        public Encoding Encoding
        {
            get
            {
                return _encoding;
            }
        }

        private string _strEncoding;
        /// <summary>
        /// 传输时的charset设置的编码字符串
        /// </summary>
        public string StrEncoding
        {
            get
            {
                return _strEncoding;
            }
            set
            {
                try
                {
                    if (string.Empty != value)
                    {
                        _encoding = Encoding.GetEncoding(value);
                        _strEncoding = _encoding.WebName;
                    }
                }
                catch { }
            }
        }
        private bool _ieProxy = false;
        /// <summary>
        /// 是否使用IE设置的代理,默认为不使用,如果同时设置了自定义代理和IE代理,则只使用IE代理
        /// </summary>
        public bool IEProxy
        {
            get { return _ieProxy; }
            set { _ieProxy = value; }
        }
        private string _proxyHost;
        /// <summary>
        /// 代理服务器地址
        /// </summary>
        public string ProxyHost
        {
            get { return _proxyHost; }
            set { _proxyHost = value; }
        }

        private int _proxyPort;
        /// <summary>
        /// 代理服务器端口
        /// </summary>
        public int ProxyPort
        {
            get { return _proxyPort; }
            set { _proxyPort = value; }
        }
        private string _proxyUser;
        /// <summary>
        /// 代理账号
        /// </summary>
        public string ProxyUser
        {
            get { return _proxyUser; }
            set { _proxyUser = value; }
        }

        private string _proxyPwd;
        /// <summary>
        /// 代理密码
        /// </summary>
        public string ProxyPwd
        {
            get { return _proxyPwd; }
            set { _proxyPwd = value; }
        }
        /// <summary>
        /// 完成下载通知
        /// </summary>
        public event EventHandler EndWork;
        /// <summary>
        /// 进度提示
        /// </summary>
        public event EventHandler<ProgressEventArgs> Progress;
        /// <summary>
        /// 错误触发
        /// </summary>
        public event EventHandler ErrorException;
        #endregion

        #region " 构造函数 "
        public DownloadFile()
        {
            HttpRequestCachePolicy noCachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
            WebRequest.DefaultCachePolicy = noCachePolicy;
        }
        #endregion

        #region " 开始执行 "
        /// <summary>
        /// 开始执行
        /// </summary>
        public void Start()
        {
            download();
        }
        /// <summary>
        /// 下载入口
        /// </summary>
        private void download()
        {
            int trycount = 0;
            while (trycount < TryCount)
            {
                trycount++;
                HttpWebRequest webReq = null;
                try
                {
                    webReq = CreateWebRequest();
                    if (null == webReq)
                    { continue; }

                    PostManage(webReq);

                    HttpWebResponse webRes = webReq.GetResponse() as HttpWebResponse;
                    if (null == webRes)
                    { continue; }

                    GetManage(webRes);
                    //正常完成不需要再尝试请求 
                    trycount = TryCount;
                }
                catch (Exception ex)
                {
                    //错误提示;
                    OnErrorException("D10001", ex.Message);
                }
                finally
                {
                    AbortWebRequest(webReq);
                }
            }
            OnEndWork();
        }
        #endregion

        #region " 创建请求 "
        /// <summary>
        /// 创建请求
        /// </summary>
        /// <returns></returns>
        private HttpWebRequest CreateWebRequest()
        {
            HttpWebRequest webReq = null;
            try
            {
                webReq = WebRequest.Create(Url) as HttpWebRequest;
                webReq.CachePolicy = WebRequest.DefaultCachePolicy;
                webReq.UserAgent = UserAgent;
                webReq.Timeout = Timeout;
                RequestUri = webReq.RequestUri;

                //设置Cookie
                if (null == _cookieContainer)
                {
                    _cookieContainer = new CookieContainer();
                }
                webReq.CookieContainer = CookieContainer;
                if (null != Cookie && string.Empty != Cookie)
                {
                    webReq.Headers.Add("cookie:" + Cookie);
                }
                //设置代理
                if (IEProxy)
                {
                    webReq.Proxy = WebRequest.GetSystemWebProxy();
                }
                else if (null != ProxyHost && string.Empty != ProxyHost)
                {
                    WebProxy proxy = new WebProxy(ProxyHost, ProxyPort);
                    if (null != ProxyUser && string.Empty != ProxyUser)
                    {
                        proxy.Credentials = new NetworkCredential(ProxyUser, ProxyPwd);
                        webReq.UseDefaultCredentials = true;
                    }
                    webReq.Proxy = proxy;
                }
            }
            catch (Exception ex)
            {
                OnErrorException("D10002", ex.Message);
            }
            return webReq;
        }
        #endregion

        #region " 上传处理 "
        /// <summary>
        /// 上传处理
        /// </summary>
        /// <param name="webReq"></param>
        private void PostManage(HttpWebRequest webReq)
        {
            try
            {
                if (null == PostData && null != StrPost && string.Empty != StrPost)
                {
                    PostData = _encoding.GetBytes(StrPost);
                }
                if (PostData != null && PostData.Length > 0)
                {
                    //Post写数据
                    webReq.ContentType = "application/x-www-form-urlencoded";
                    webReq.Method = "POST";
                    //设置请求的ContentLength 
                    webReq.ContentLength = PostData.Length;
                    //将请求参数写入流
                    Stream stream = webReq.GetRequestStream();
                    stream.Write(PostData, 0, PostData.Length);
                    //关闭请求流
                    stream.Close();
                    //StreamWrite(webReq.GetRequestStream(), PostData);
                }
            }
            catch (Exception ex)
            {
                OnErrorException("D10003", ex.Message);
            }
        }

        /// <summary>
        /// 写入数据
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="postData"></param>
        private void StreamWrite(Stream stream, byte[] postData)
        {
            int uploadByte = 1024, allByte = postData.Length, offset = 0;
            ProgressEventArgs e = new ProgressEventArgs();
            e.MethodType = "POST";
            e.Length = postData.Length;
            do
            {
                uploadByte = (postData.Length - offset) > uploadByte ? uploadByte : (postData.Length - offset);
                stream.Write(postData, offset, uploadByte);
                offset += uploadByte;
                e.Position = offset;
                OnProgress(e);
            } while (offset < postData.Length);
            stream.Close();//关闭当前流并释放与之关联的所以资源
        }

        #endregion

        #region " 下载处理 "
        /// <summary>
        /// 下载处理
        /// </summary>
        /// <param name="webRes"></param>
        private void GetManage(HttpWebResponse webRes)
        {
            ResponseUri = webRes.ResponseUri;
            if (null != CookieContainer && CookieContainer.Count > 0)
            {
                webRes.Cookies = CookieContainer.GetCookies(RequestUri);
            }
            if (string.Empty != webRes.CharacterSet)
            {
                StrEncoding = webRes.CharacterSet;
            }

            StreamRead(webRes.GetResponseStream(), webRes.ContentLength);
            //当下载数据源为文本时,把流转按指定编码换成文本
            if (null != _getData
                && _getData.Length > 0
                && Regex.IsMatch(webRes.ContentType, "(text|xml)", RegexOptions.IgnoreCase))
            {
                if (null == StrEncoding || string.Empty == StrEncoding)
                {
                    string tmptext = Encoding.Default.GetString(GetData);
                    //通过默认编码解析得到真正的字符编码
                    GetEncoding(tmptext);
                    if (string.Empty != StrEncoding && _encoding != Encoding.Default)
                    {
                        //默认解析编码与正常数据不同时,重新解析字串
                        tmptext = _encoding.GetString(GetData);
                    }
                    HtmlText = tmptext;
                }
                else
                {
                    HtmlText = _encoding.GetString(GetData);
                }
            }
        }

        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="stream"></param>
        private void StreamRead(Stream stream, long length)
        {
            ProgressEventArgs e = new ProgressEventArgs();
            e.MethodType = "GET";
            e.Length = length;
            _getData = new byte[length < 0 ? 0 : length];
            int downByte = 0, allByte = 10240, tryag = 3;
            long position = 0;
            do
            {
                byte[] buffer = new byte[allByte];
                downByte = stream.Read(buffer, 0, allByte);
                if (downByte > 0)
                {
                    if (length <= 0)
                    {
                        byte[] buff = _getData;
                        _getData = new byte[downByte + _getData.Length];
                        if (buff.Length > 0)
                        {
                            Array.Copy(buff, 0, _getData, 0, buff.Length);
                        }
                    }
                    Array.Copy(buffer, 0, _getData, position, downByte);
                    position += downByte;
                    e.Position = position;
                    OnProgress(e);
                }
                else
                {
                    tryag--;
                }
            } while (downByte > 0 || tryag > 0);
        }
        #endregion

        #region " 结束请求 "
        /// <summary>
        /// 结束请求
        /// </summary>
        /// <param name="webReq"></param>
        private void AbortWebRequest(HttpWebRequest webReq)
        {
            if (null != webReq)
            {
                webReq.Abort();
            }
        }
        #endregion

        #region " 事件通知 "
        /// <summary>
        /// 结束通知
        /// </summary>
        protected void OnEndWork()
        {
            if (null != EndWork)
            {
                EndWork(this, new EventArgs());
            }
        }
        /// <summary>
        /// 进度通知
        /// </summary>
        /// <param name="e"></param>
        protected void OnProgress(ProgressEventArgs e)
        {
            if (null != Progress)
            {
                Progress(this, e);
            }
        }
        /// <summary>
        /// 错误通知
        /// </summary>
        /// <param name="key"></param>
        /// <param name="errorMsg"></param>
        protected void OnErrorException(string key, string errorMsg)
        {
            if (null != ErrorException)
            {
                ErrorException(string.Format("{0}:{1}:{2}", key, DateTime.Now.ToString("MMdd-HHmm"), errorMsg), new EventArgs());
            }
        }
        #endregion

        #region " 获取编码 "
        /// <summary>
        /// 获取编码
        /// </summary>
        /// <param name="value"></param>
        protected void GetEncoding(string value)
        {
            if (null == StrEncoding || string.Empty == StrEncoding)
            {
                string rcharset = @"(?<=charset[ ]*=[ ]*\W?)\b(\w+)(-\w+)*\b";
                StrEncoding = Regex.Match(value, rcharset, RegexOptions.IgnoreCase).Value;
            }
        }
        #endregion

        #region " 转义替换 "
        /// <summary>
        /// 转义字符的转换
        /// </summary>
        /// <param name="htmlText"></param>
        private string AnalyticalReplace(string htmlText)
        {
            try
            {
                while (Regex.IsMatch(htmlText, @"&#\d+;"))
                {
                    string value = Regex.Match(htmlText, @"&#\d+;").Value;
                    int num;
                    bool tryparse = int.TryParse(value.Replace(";", "").Replace("&#", ""), out num);
                    if (tryparse)
                    {
                        string nv = Convert.ToChar(num).ToString();
                        htmlText = Regex.Replace(htmlText, value, nv);
                    }
                    else
                    {
                        htmlText = Regex.Replace(htmlText, value, "");
                    }
                }
            }
            catch (Exception ex)
            {
                OnErrorException("D10004", ex.Message);
            }
            return htmlText;
        }
        #endregion
    }
}
