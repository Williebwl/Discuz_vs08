using System;
using System.IO;
using System.Web;
using System.Text.RegularExpressions;

using Discuz.Forum;
using Discuz.Common;
using Discuz.Common.Generic;
using Discuz.Config;
using Discuz.Entity;
using Discuz.Plugin.Space;
using Discuz.Plugin.Album;
using Discuz.Plugin.Mall;
using System.Text;
using Newtonsoft.Json;

namespace Discuz.Forum
{
    /// <summary>
    /// Discuz!NT页面基类
    /// </summary>
    public class PageBase : System.Web.UI.Page
    {
        /// <summary>
        /// 论坛配置信息
        /// </summary>
        protected internal GeneralConfigInfo config;
        /// <summary>
        /// 当前用户的用户组信息
        /// </summary>
        protected internal UserGroupInfo usergroupinfo;
        /// <summary>
        /// 在线用户信息
        /// </summary>
        protected internal OnlineUserInfo oluserinfo;
        /// <summary>
        /// 当前用户的用户名
        /// </summary>
        protected internal string username;
        /// <summary>
        /// 当前用户的密码
        /// </summary>
        protected internal string password;
        /// <summary>
        /// 当前用户的特征串
        /// </summary>
        protected internal string userkey;
        /// <summary>
        /// 当前用户的用户ID
        /// </summary>
        protected internal int userid;
        /// <summary>
        /// 当前用户的在线表ID
        /// </summary>
        protected internal int olid;
        /// <summary>
        /// 当前用户的用户组ID
        /// </summary>
        protected internal int usergroupid;
        /// <summary>
        /// 当前用户的管理权限，1为管理员，2为超版，3为版主，-1为特殊组。
        /// 如果需要获得admingroup信息，请勿使用此值，使用usergroupid作为条件查询即可
        /// </summary>
        protected internal int useradminid;
        /// <summary>
        /// 当前用户的最后发帖时间
        /// </summary>
        protected internal string lastposttime;
        /// <summary>
        /// 当前用户的最后发短消息时间
        /// </summary>
        protected internal string lastpostpmtime;
        /// <summary>
        /// 当前用户的最后搜索时间
        /// </summary>
        protected internal string lastsearchtime;
        /// <summary>
        /// 当前用户所使用的短信息铃声编号
        /// </summary>
        protected internal int pmsound;
        /// <summary>
        /// 当前页面是否被POST请求
        /// </summary>
        protected internal bool ispost;
        /// <summary>
        /// 当前页面是否被GET请求
        /// </summary>
        protected internal bool isget;
        /// <summary>
        /// 当前用户的短消息数目
        /// </summary>
        protected internal int newpmcount = 0;
        /// <summary>
        /// 当前用户的短消息数目
        /// </summary>
        protected internal int realnewpmcount = 0;
        /// <summary>
        /// 当前页面标题
        /// </summary>
        protected internal string pagetitle = "页面";
        /// <summary>
        /// 模板id
        /// </summary>
        protected internal int templateid;
        /// <summary>
        /// 模板风格选择列表框选项
        /// </summary>
        protected internal string templatelistboxoptions;
        /// <summary>
        /// 当前模板路径
        /// </summary>
        protected internal string templatepath;
        /// <summary>
        /// 当前日期
        /// </summary>
        protected internal string nowdate;
        /// <summary>
        /// 当前时间
        /// </summary>
        protected internal string nowtime;
        /// <summary>
        /// 当前日期时间
        /// </summary>
        protected internal string nowdatetime;
        /// <summary>
        /// 当前页面Meta字段内容
        /// </summary>
        protected internal string meta = "";
        /// <summary>
        /// 当前页面Link字段内容
        /// </summary>
        protected internal string link;
        /// <summary>
        /// 当前页面中增加script
        /// </summary>
        protected internal string script;
        /// <summary>
        /// 当前页面检查到的错误数
        /// </summary>
        protected internal int page_err = 0;
        /// <summary>
        /// 提示文字
        /// </summary>
        protected internal string msgbox_text = "";
        /// <summary>
        /// 用户中心提示文字
        /// </summary>
        protected internal string usercpmsgbox_text = "";
        /// <summary>
        /// 是否显示回退的链接
        /// </summary>
        protected internal string msgbox_showbacklink = "true";
        /// <summary>
        /// 回退链接的内容
        /// </summary>
        protected internal string msgbox_backlink = "javascript:history.back();";
        /// <summary>
        /// 返回到的页面url地址
        /// </summary>
        protected internal string msgbox_url = "";
        /// <summary>
        /// 多少分钟之前的帖子为新帖
        /// </summary>
        protected internal int newtopicminute = 120;
        /// <summary>
        /// 当前在线人数
        /// </summary>
        protected internal int onlineusercount = 1;
        /// <summary>
        ///	头部广告
        /// </summary>
        protected internal string headerad = "";
        /// <summary>
        /// 底部广告
        /// </summary>
        protected internal string footerad = "";
        /// <summary>
        /// 页面内容
        /// </summary>
        protected internal System.Text.StringBuilder templateBuilder = new System.Text.StringBuilder();
        /// <summary>
        /// 是否为需检测校验码页面
        /// </summary>
        protected bool isseccode = true;
        /// <summary>
        /// 是否为游客缓存页
        /// </summary>
        protected int isguestcachepage = 0;
        /// <summary>
        /// 导航主菜单
        /// </summary>
        protected string mainnavigation;
        /// <summary>
        /// 导航子菜单
        /// </summary>
        protected System.Data.DataTable subnavigation;
        /// <summary>
        /// 带有子菜单的主导航菜单
        /// </summary>
        protected string[] mainnavigationhassub;
        /// <summary>
        /// 当前页面开始载入时间(毫秒)
        /// </summary>
        private DateTime m_starttick;
        /// <summary>
        /// 当前页面执行时间(毫秒)
        /// </summary>
        private double m_processtime;
        /// <summary>
        /// 当前页面名称
        /// </summary>
        public string pagename = DNTRequest.GetPageName();
        /// <summary>
        /// 空间地址
        /// </summary>
        public string spaceurl = "";
        /// <summary>
        /// 相册地址
        /// </summary>
        public string albumurl = "";
        /// <summary>
        /// 论坛地址
        /// </summary>
        public string forumurl = "";
        /// <summary>
        /// 查询次数统计
        /// </summary>
        public int querycount = 0;
        /// <summary>
        /// 论坛相对根的路径
        /// </summary>
        public string forumpath = BaseConfigs.GetForumPath;
        /// <summary>
        /// 获取站点根目录URL
        /// </summary>
        public string rooturl = Utils.GetRootUrl(BaseConfigs.GetForumPath);
        /// <summary>
        /// 模板图片目录(可以是绝对或相对地址)
        /// </summary>
        public string imagedir = "default/images";
        /// <summary>
        /// 模板CSS目录(可以是绝对或相对地址)
        /// </summary>
        public string cssdir = "default";
        /// <summary>
        /// js目录(可以是绝对或相对地址)
        /// </summary>
        public string jsdir = "javascript";
        /// <summary>
        /// 主题鉴定图片目录(可以是绝对或相对地址)
        /// </summary>
        public string topicidentifydir = "images/identify/";
        /// <summary>
        /// 主题图标目录(可以是绝对或相对地址)
        /// </summary>
        public string posticondir = "images/posticons/";
        /// <summary>
        /// 用户头像
        /// </summary>
        public string useravatar = "";
        /// <summary>
        /// 获取主题(附件)买卖使用的积分字段
        /// </summary>
        public int topicattachscorefield = Scoresets.GetTopicAttachCreditsTrans();
        /// <summary>
        /// 返回ajax格式结果
        /// </summary>
        public int inajax = DNTRequest.GetInt("inajax", 0);
        /// <summary>
        /// 浮动窗体
        /// </summary>
        public int infloat = DNTRequest.GetInt("infloat", 0);
        /// <summary>
        /// 暂用于显示用户积分和对应的组别
        /// </summary>
        public string userinfotips = "";
        /// <summary>
        /// 用于检测头部登录时是否启用验证码
        /// </summary>
        public bool isLoginCode = true;
        /// <summary>
        /// 是否加载窄屏样式
        /// </summary>
        public bool isnarrowpage = false;
        /// <summary>
        /// 安全提问问题id
        /// </summary>
        public int question = DNTRequest.GetQueryInt("question", 0);
#if DEBUG
        public string querydetail = "";
#endif


        #region 外部登录新增加字段
        /// <summary>
        /// 需要激活的用户id
        /// </summary>
        public int needactiveuid = -1;
        /// <summary>
        /// 重置的Email信息的有效时间
        /// </summary>
        public string timestamp = "";
        /// <summary>
        /// 重设Email的加密校验，确保是该用户在当前页面操作的
        /// </summary>
        public string authstr = "";
        /// <summary>
        /// 是否跨页面提交
        /// </summary>
        public bool loginsubmit = DNTRequest.GetString("loginsubmit") == "true" ? true : false;
        /// <summary>
        /// 登陆时的密码验证信息
        /// </summary>
        public string loginauth = DNTRequest.GetString("loginauth");
        #endregion


        /// <summary>
        /// 获得游客缓存
        /// </summary>
        /// <param name="pagename"></param>
        /// <returns></returns>
        private int GetCachePage(string pagename)
        {
            Discuz.Cache.DNTCache cache = Discuz.Cache.DNTCache.GetCacheService();
            //Discuz.Cache.ICacheStrategy ics = new ForumCacheStrategy();
            //ics.TimeOut = config.Guestcachepagetimeout * 60;
            //cache.LoadCacheStrategy(ics);
            string str = cache.RetrieveObject("/Forum/GuestCachePage/" + pagename) as string;
            //cache.LoadDefaultCacheStrategy();
            if (str != null && str.Length > 1)
            {
                System.Web.HttpContext.Current.Response.Write(str);
                System.Web.HttpContext.Current.Response.End();
                return 2;
            }
            return 1;
        }

        /// <summary>
        /// 判断页面是否需要游客缓存页
        /// </summary>
        /// <param name="pagename"></param>
        /// <returns>不需要返回false</returns>
        private bool GetUserCachePage(string pagename)
        {
            switch (pagename)
            {
                case "website.aspx":
                    isguestcachepage = GetCachePage(pagename);
                    break;
                case "forumindex.aspx":
                    isguestcachepage = GetCachePage(pagename);
                    break;
                case "spaceindex.aspx":
                    isguestcachepage = GetCachePage(pagename);
                    break;
                case "albumindex.aspx":
                    isguestcachepage = GetCachePage(pagename);
                    break;
                case "showtopic.aspx":
                    {
                        int pageid = DNTRequest.GetQueryInt("page", 1);
                        int topicid = DNTRequest.GetQueryInt("topicid", 0);
                        //参数数目为2或0表示当前页面可能为第一页帖子列表
                        if ((DNTRequest.GetParamCount() == 2 || DNTRequest.GetParamCount() == 3) && topicid > 0 && ForumUtils.ResponseShowTopicCacheFile(topicid, pageid))
                        {
                            TopicStats.Track(topicid, 1);
                            return true;
                        }
                        break;
                    }
                case "showforum.aspx":
                    {
                        int pageid = DNTRequest.GetQueryInt("page", 1);
                        int forumid = DNTRequest.GetQueryInt("forumid", 0);
                        //参数数目为2或0表示当前页面可能为第一页帖子列表
                        if ((DNTRequest.GetParamCount() == 2 || DNTRequest.GetParamCount() == 3) && forumid > 0 && ForumUtils.ResponseShowForumCacheFile(forumid, pageid))
                            return true;

                        break;
                    }
                default:
                    break;
            }
            return false;
        }

        /// <summary>
        /// 校验用户是否可以访问论坛
        /// </summary>
        /// <returns></returns>
        private bool ValidateUserPermission()
        {
            if (onlineusercount >= config.Maxonlines && useradminid != 1 && pagename != "login.aspx" && pagename != "logout.aspx")
            {
                ShowMessage("抱歉,目前访问人数太多,你暂时无法访问论坛.", 0);
                return false;
            }

            if (usergroupinfo.Allowvisit != 1 && useradminid != 1 && pagename != "login.aspx" && pagename != "register.aspx" && pagename != "logout.aspx" && pagename != "activationuser.aspx" && pagename != "getpassword.aspx")
            {
                ShowMessage("抱歉, 您所在的用户组不允许访问论坛", 2);
                return false;
            }

            // 如果IP访问列表有设置则进行判断
            if (config.Ipaccess.Trim() != "")
            {
                string[] regctrl = Utils.SplitString(config.Ipaccess, "\n");
                if (!Utils.InIPArray(DNTRequest.GetIP(), regctrl))
                {
                    ShowMessage("抱歉, 系统设置了IP访问列表限制, 您无法访问本论坛", 0);
                    return false;
                }
            }


            // 如果IP访问列表有设置则进行判断
            if (config.Ipdenyaccess.Trim() != "")
            {
                string[] regctrl = Utils.SplitString(config.Ipdenyaccess, "\n");
                if (Utils.InIPArray(DNTRequest.GetIP(), regctrl))
                {
                    ShowMessage("由于您严重违反了论坛的相关规定, 已被禁止访问.", 2);
                    return false;
                }
            }

            //　如果当前用户请求页面不是登录页面并且当前用户非管理员并且论坛设定了时间段,当时间在其中的一个时间段内,则跳转到论坛登录页面
            if (useradminid != 1 && pagename != "login.aspx" && pagename != "logout.aspx" && usergroupinfo.Disableperiodctrl != 1)
            {
                if (Scoresets.BetweenTime(config.Visitbanperiods))
                {
                    ShowMessage("在此时间段内不允许访问本论坛", 2);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 校验验证码
        /// </summary>
        private bool ValidateVerifyCode()
        {
            if (DNTRequest.GetString("vcode") == "")
            {
                if (pagename == "showforum.aspx")
                {
                    //版块如不设置密码,必无校验码
                    //return;
                }
                else if (pagename.EndsWith("ajax.aspx"))
                {
                    if (DNTRequest.GetString("t") == "quickreply")
                    {
                        ResponseAjaxVcodeError();
                        return false;
                    }
                }
                else
                {
                    if (DNTRequest.GetString("loginsubmit") == "true" && pagename == "login.aspx")//添加快捷登陆方式的验证码判断
                    {
                        //快速登录时不报错
                    }
                    else if (DNTRequest.GetFormString("agree") == "true" && pagename == "register.aspx")
                    {
                        //同意注册协议也不受此限制
                    }
                    else
                    {
                        AddErrLine("验证码错误");
                        return false;
                    }
                }
            }
            else
            {

                if (!OnlineUsers.CheckUserVerifyCode(olid, DNTRequest.GetString("vcode")))
                {
                    if (pagename.EndsWith("ajax.aspx"))
                    {
                        ResponseAjaxVcodeError();
                        return false;
                    }
                    else
                    {
                        AddErrLine("验证码错误");
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 从config文件中获取并设置论坛, 空间, 相册的不带页面名称的url路径
        /// (返回绝对或相对地址)
        /// </summary>
        private void LoadUrlConfig()
        {
            spaceurl = config.Spaceurl.ToLower();
            if (spaceurl.IndexOf("http://") == 0)
            {
                if (spaceurl.EndsWith("aspx"))
                    spaceurl = spaceurl.Substring(0, spaceurl.LastIndexOf('/')) + "/";
                else if (!spaceurl.EndsWith("/"))
                    spaceurl = spaceurl + "/";
            }
            else
                spaceurl = "";

            albumurl = config.Albumurl.ToLower();
            if (albumurl.IndexOf("http://") == 0)
            {
                if (albumurl.EndsWith("aspx"))
                    albumurl = albumurl.Substring(0, albumurl.LastIndexOf('/')) + "/";
                else if (!albumurl.EndsWith("/"))
                    albumurl = albumurl + "/";
            }
            else
                albumurl = "";

            forumurl = config.Forumurl.ToLower();
            if (forumurl.IndexOf("http://") == 0)
            {
                if (forumurl.EndsWith("aspx") || forumurl.EndsWith("htm") || forumurl.EndsWith("html"))
                    forumurl = forumurl.Substring(0, forumurl.LastIndexOf('/')) + "/";
                else if (!forumurl.EndsWith("/"))
                    forumurl = forumurl + "/";
            }
            else
                forumurl = BaseConfigs.GetForumPath;
        }

        #region 负载均衡环境下PV统计
        private static bool recordPageView = LoadBalanceConfigs.GetConfig() != null &&
                                             LoadBalanceConfigs.GetConfig().AppLoadBalance &&
                                             LoadBalanceConfigs.GetConfig().RecordPageView;

        private static Dictionary<string, int> pageViewStatistic = new Dictionary<string, int>();

        public static void PageViewStatistic(string pagename)
        {
            if (pageViewStatistic.Count == 0)
                pageViewStatistic.Add(Utils.GetDateTime(), -1); //统计开启时间          

            if (pageViewStatistic.ContainsKey(pagename))
                pageViewStatistic[pagename] = pageViewStatistic[pagename] + 1;
            else
                pageViewStatistic.Add(pagename, 1);
        }

        public static Dictionary<string, int> PageViewSatisticInfo
        {
            get { return pageViewStatistic; }
            set { pageViewStatistic = value; }

        }
        #endregion

        #region 外部登录方法
        private void APILogin(APIConfigInfo apiInfo)
        {
            ApplicationInfo appInfo = null;
            ApplicationInfoCollection appcollection = apiInfo.AppCollection;
            foreach (ApplicationInfo newapp in appcollection)
            {
                if (newapp.APIKey == DNTRequest.GetString("api_key"))
                    appInfo = newapp;
            }

            if (appInfo == null)
                return;

            this.Load += delegate
            {
                RedirectAPILogin(appInfo);
                this.Load += delegate { };
            };
        }

        private void RedirectAPILogin(ApplicationInfo appInfo)
        {
            string expires = DNTRequest.GetFormString("expires");
            DateTime expireUTCTime;
            if (Utils.StrIsNullOrEmpty(expires))
                expireUTCTime = DateTime.Parse(Users.GetShortUserInfo(userid).Lastvisit).ToUniversalTime().AddSeconds(
                    Convert.ToDouble(Request.Cookies["dnt"]["expires"].ToString()));
            else
                expireUTCTime = DateTime.UtcNow.AddSeconds(Convert.ToDouble(expires));

            expires = Utils.ConvertToUnixTimestamp(expireUTCTime).ToString();

            //CreateToken
            OnlineUsers.UpdateAction(olid, UserAction.Login.ActionID, 0);
            string next = DNTRequest.GetString("next");
            string time = "";
            OnlineUserInfo oui = OnlineUsers.GetOnlineUser(olid);
            if (oui == null)
                time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            else
                time = DateTime.Parse(oui.Lastupdatetime).ToString("yyyy-MM-dd HH:mm:ss");

            string authToken = DES.Encode(string.Format("{0},{1},{2}", olid, time, expires), appInfo.Secret.Substring(0, 10)).Replace("+", "[");
            Response.Redirect(string.Format("{0}{1}auth_token={2}{3}", appInfo.CallbackUrl, appInfo.CallbackUrl.IndexOf("?") > 0 ? "&" : "?", authToken, next == "" ? next : "&next=" + next));
        }

        private void SetLeftMenuRefresh()
        {
            SetMetaRefresh();
            SetShowBackLink(false);
            AddScript("if (top.document.getElementById('leftmenu')){top.frames['leftmenu'].location.reload();}");
        }

        #region 登录注册
        /// <summary>
        /// 创建用户信息
        /// </summary>
        /// <param name="tmpUsername"></param>
        /// <param name="email"></param>
        /// <param name="tmpBday"></param>
        /// <returns></returns>
        private UserInfo CreateUser(string tmpUsername, string email, string tmpBday, string mobile)
        {
            // 如果找不到0积分的用户组则用户自动成为待验证用户
            UserInfo userinfo = new UserInfo();
            userinfo.Username = tmpUsername;
            userinfo.Nickname = Utils.HtmlEncode(ForumUtils.BanWordFilter(DNTRequest.GetString("nickname")));
            userinfo.Password = DNTRequest.GetString("password");
            userinfo.Secques = ForumUtils.GetUserSecques(DNTRequest.GetInt("question", 0), DNTRequest.GetString("answer"));
            userinfo.Gender = DNTRequest.GetInt("gender", 0);
            userinfo.Adminid = 0;
            userinfo.Groupexpiry = 0;
            userinfo.Extgroupids = "";
            userinfo.Regip = DNTRequest.GetIP();
            userinfo.Joindate = Utils.GetDateTime();
            userinfo.Lastip = DNTRequest.GetIP();
            userinfo.Lastvisit = Utils.GetDateTime();
            userinfo.Lastactivity = Utils.GetDateTime();
            userinfo.Lastpost = Utils.GetDateTime();
            userinfo.Lastpostid = 0;
            userinfo.Lastposttitle = "";
            userinfo.Posts = 0;
            userinfo.Digestposts = 0;
            userinfo.Oltime = 0;
            userinfo.Pageviews = 0;
            userinfo.Credits = 0;
            userinfo.Extcredits1 = Scoresets.GetScoreSet(1).Init;
            userinfo.Extcredits2 = Scoresets.GetScoreSet(2).Init;
            userinfo.Extcredits3 = Scoresets.GetScoreSet(3).Init;
            userinfo.Extcredits4 = Scoresets.GetScoreSet(4).Init;
            userinfo.Extcredits5 = Scoresets.GetScoreSet(5).Init;
            userinfo.Extcredits6 = Scoresets.GetScoreSet(6).Init;
            userinfo.Extcredits7 = Scoresets.GetScoreSet(7).Init;
            userinfo.Extcredits8 = Scoresets.GetScoreSet(8).Init;
            //userinfo.Avatarshowid = 0;
            userinfo.Email = email;
            userinfo.Bday = tmpBday;
            userinfo.Sigstatus = DNTRequest.GetInt("sigstatus", 1) != 0 ? 1 : 0;
            userinfo.Tpp = DNTRequest.GetInt("tpp", 0);
            userinfo.Ppp = DNTRequest.GetInt("ppp", 0);
            userinfo.Templateid = DNTRequest.GetInt("templateid", 0);
            userinfo.Pmsound = DNTRequest.GetInt("pmsound", 0);
            userinfo.Showemail = DNTRequest.GetInt("showemail", 0);
            userinfo.Salt = "";

            int receivepmsetting = config.Regadvance == 0 ? 3 : DNTRequest.GetInt("receivesetting", 3);//关于短信息枚举值的设置看ReceivePMSettingType类型注释，此处不禁止用户接受系统短信息
            //foreach (string rpms in DNTRequest.GetString("receivesetting").Split(','))
            //{
            //    if (!Utils.StrIsNullOrEmpty(rpms))
            //        receivepmsetting = receivepmsetting | int.Parse(rpms);
            //}

            //if (config.Regadvance == 0)
            //    receivepmsetting = 7;

            userinfo.Newsletter = (ReceivePMSettingType)receivepmsetting;
            userinfo.Invisible = DNTRequest.GetInt("invisible", 0);
            userinfo.Newpm = config.Welcomemsg == 1 ? 1 : 0;
            userinfo.Medals = "";
            userinfo.Accessmasks = DNTRequest.GetInt("accessmasks", 0);
            userinfo.Website = Utils.HtmlEncode(DNTRequest.GetString("website"));
            userinfo.Icq = Utils.HtmlEncode(DNTRequest.GetString("icq"));
            userinfo.Qq = Utils.HtmlEncode(DNTRequest.GetString("qq"));
            userinfo.Yahoo = Utils.HtmlEncode(DNTRequest.GetString("yahoo"));
            userinfo.Msn = Utils.HtmlEncode(DNTRequest.GetString("msn"));
            userinfo.Skype = Utils.HtmlEncode(DNTRequest.GetString("skype"));
            userinfo.Location = Utils.HtmlEncode(DNTRequest.GetString("location"));
            userinfo.Customstatus = (usergroupinfo.Allowcstatus == 1) ? Utils.HtmlEncode(DNTRequest.GetString("customstatus")) : "";
            //userinfo.Avatar = @"avatars\common\0.gif";
            //userinfo.Avatarwidth = 0;
            //userinfo.Avatarheight = 0;
            userinfo.Bio = ForumUtils.BanWordFilter(DNTRequest.GetString("bio"));
            userinfo.Signature = Utils.HtmlEncode(ForumUtils.BanWordFilter(DNTRequest.GetString("signature")));

            PostpramsInfo postpramsinfo = new PostpramsInfo();
            postpramsinfo.Usergroupid = usergroupid;
            postpramsinfo.Attachimgpost = config.Attachimgpost;
            postpramsinfo.Showattachmentpath = config.Showattachmentpath;
            postpramsinfo.Hide = 0;
            postpramsinfo.Price = 0;
            postpramsinfo.Sdetail = userinfo.Signature;
            postpramsinfo.Smileyoff = 1;
            postpramsinfo.Bbcodeoff = 1 - usergroupinfo.Allowsigbbcode;
            postpramsinfo.Parseurloff = 1;
            postpramsinfo.Showimages = usergroupinfo.Allowsigimgcode;
            postpramsinfo.Allowhtml = 0;
            postpramsinfo.Smiliesinfo = Smilies.GetSmiliesListWithInfo();
            postpramsinfo.Customeditorbuttoninfo = Editors.GetCustomEditButtonListWithInfo();
            postpramsinfo.Smiliesmax = config.Smiliesmax;
            userinfo.Sightml = UBB.UBBToHTML(postpramsinfo);

            userinfo.Authtime = Utils.GetDateTime();

            //邮箱激活链接验证
            if (config.Regverify == 1)
            {
                userinfo.Authstr = ForumUtils.CreateAuthStr(20);
                userinfo.Authflag = 1;
                userinfo.Groupid = 8;
                //SendEmail(tmpUsername, DNTRequest.GetString("password").Trim(), DNTRequest.GetString(config.Antispamregisteremail).Trim(), userinfo.Authstr);
            }
            //系统管理员进行后台验证
            else if (config.Regverify == 2)
            {
                userinfo.Authstr = DNTRequest.GetString("website");
                userinfo.Groupid = 8;
                userinfo.Authflag = 1;
            }
            else
            {
                userinfo.Authstr = "";
                userinfo.Authflag = 0;
                userinfo.Groupid = UserCredits.GetCreditsUserGroupId(0).Groupid;
            }
            userinfo.Realname = DNTRequest.GetString("realname");
            userinfo.Idcard = DNTRequest.GetString("idcard");
            userinfo.Mobile = mobile;
            userinfo.Phone = DNTRequest.GetString("phone");
            userinfo.Password = Utils.MD5(userinfo.Password);
            Users.CreateUser(userinfo);
            return userinfo;
        }
        #endregion

        #region 更新会员信息
        /// <summary>
        /// 检查除签名外的其他用户资料修改
        /// </summary>
        /// <param name="oldUserInfo"></param>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        private bool CheckModified(UserInfo oldUserInfo, UserInfo userInfo)
        {
            return
                userInfo.Uid != oldUserInfo.Uid ||
                userInfo.Nickname != oldUserInfo.Nickname ||
                userInfo.Gender != oldUserInfo.Gender ||
                userInfo.Realname != oldUserInfo.Realname ||
                userInfo.Idcard != oldUserInfo.Idcard ||
                userInfo.Mobile != oldUserInfo.Mobile ||
                userInfo.Phone != oldUserInfo.Phone ||
                userInfo.Email != oldUserInfo.Email ||
                userInfo.Bday != oldUserInfo.Bday ||
                userInfo.Showemail != oldUserInfo.Showemail ||
                userInfo.Website != oldUserInfo.Website ||

                userInfo.Icq != oldUserInfo.Icq ||
                userInfo.Qq != oldUserInfo.Qq ||
                userInfo.Yahoo != oldUserInfo.Yahoo ||
                userInfo.Msn != oldUserInfo.Msn ||
                userInfo.Skype != oldUserInfo.Skype ||
                userInfo.Location != oldUserInfo.Location ||
                userInfo.Bio != oldUserInfo.Bio ||
                userInfo.Signature != oldUserInfo.Signature ||
                userInfo.Sigstatus != oldUserInfo.Sigstatus;
        }
        #endregion

        #region 获取用户id
        /// <summary>
        /// 获取用户id
        /// </summary>
        /// <returns></returns>
        private ShortUserInfo GetShortUserInfo(string postusername, string mobile, string email)
        {
            int uid = -1;

            #region 现在的登录
            //现在的登录
            uid = Users.GetUserId(postusername);
            if (uid > 0)//更新用户手机号、邮箱
            {
                #region 更新用户手机号、邮箱
                UserInfo oldUserInfo = Users.GetUserInfo(uid);
                UserInfo userInfo = oldUserInfo.Clone();
                //需要判断签名是否修改过
                string sig = oldUserInfo.Sightml;//保存旧的签名
                userInfo.Uid = uid;
                userInfo.Username = postusername;//当前登录的用户名


                #region 基本资料
                //userInfo.Realname = DNTRequest.GetString("realname");
                //userInfo.Gender = DNTRequest.GetInt("gender", 0);
                //userInfo.Bday = Utils.HtmlEncode(DNTRequest.GetString("bday"));
                //userInfo.Location = Utils.HtmlEncode(DNTRequest.GetString("location"));
                //userInfo.Idcard = DNTRequest.GetString("idcard");
                //userInfo.Nickname = Utils.HtmlEncode(ForumUtils.BanWordFilter(DNTRequest.GetString("nickname"))); 
                //userInfo.Bio = Utils.HtmlEncode(ForumUtils.BanWordFilter(DNTRequest.GetString("bio")));
                #endregion

                #region 联系方式
                userInfo.Mobile = mobile;
                //userInfo.Phone = DNTRequest.GetString("phone");
                userInfo.Email = email;

                //if (userInfo.Email != oldUserInfo.Email && !Users.ValidateEmail(userInfo.Email, userid))
                //{
                //    AddErrLine("Email: \"" + userInfo.Email + "\" 已经被其它用户注册使用");
                //    return;
                //}
                //userInfo.Showemail = DNTRequest.GetInt("showemail", 1);

                //if (DNTRequest.GetString("website").IndexOf(".") > -1 && !DNTRequest.GetString("website").ToLower().StartsWith("http"))
                //    userInfo.Website = Utils.HtmlEncode("http://" + DNTRequest.GetString("website"));
                //else
                //    userInfo.Website = Utils.HtmlEncode(DNTRequest.GetString("website"));
                //userInfo.Msn = Utils.HtmlEncode(DNTRequest.GetString("msn"));
                //userInfo.Qq = Utils.HtmlEncode(DNTRequest.GetString("qq"));
                //userInfo.Skype = Utils.HtmlEncode(DNTRequest.GetString("skype"));
                //userInfo.Icq = Utils.HtmlEncode(DNTRequest.GetString("icq"));
                //userInfo.Yahoo = Utils.HtmlEncode(DNTRequest.GetString("yahoo"));

                #endregion

                #region 签名
                //PostpramsInfo postPramsInfo = new PostpramsInfo();
                //postPramsInfo.Usergroupid = usergroupid;
                //postPramsInfo.Attachimgpost = config.Attachimgpost;
                //postPramsInfo.Showattachmentpath = config.Showattachmentpath;
                //postPramsInfo.Hide = 0;
                //postPramsInfo.Price = 0;
                ////获取提交的内容并进行脏字和Html处理
                ////postPramsInfo.Sdetail = Utils.HtmlEncode(ForumUtils.BanWordFilter(DNTRequest.GetString("signature"))); ;
                //postPramsInfo.Smileyoff = 1;
                //postPramsInfo.Bbcodeoff = 1 - usergroupinfo.Allowsigbbcode;
                //postPramsInfo.Parseurloff = 1;
                //postPramsInfo.Showimages = usergroupinfo.Allowsigimgcode;
                //postPramsInfo.Allowhtml = 0;
                //postPramsInfo.Signature = 1;
                //postPramsInfo.Smiliesinfo = Smilies.GetSmiliesListWithInfo();
                //postPramsInfo.Customeditorbuttoninfo = null;
                //postPramsInfo.Smiliesmax = config.Smiliesmax;
                //postPramsInfo.Signature = 1;

                //userInfo.Sightml = UBB.UBBToHTML(postPramsInfo);
                //if (sig != userInfo.Sightml)
                //{
                //    Sync.UpdateSignature(userid, userInfo.Username, userInfo.Sightml, "");
                //}
                //if (userInfo.Sightml.Length >= 1000)
                //{
                //    AddErrLine("您的签名转换后超出系统最大长度， 请返回修改");
                //    return;
                //}

                //userInfo.Signature = postPramsInfo.Sdetail;
                //userInfo.Sigstatus = DNTRequest.GetInt("sigstatus", 0) != 0 ? 1 : 0; 
                #endregion


                if (CheckModified(oldUserInfo, userInfo))
                {
                    Users.UpdateUserProfile(userInfo);
                    Sync.UpdateProfile(userInfo.Uid, userInfo.Username, "");
                }
                OnlineUsers.DeleteUserByUid(userid);    //删除在线表中的信息，使之重建该用户在线表信息
                //ManyouApplications.AddUserLog(userid, UserLogActionEnum.Update);

                //ForumUtils.WriteCookie("sigstatus", userInfo.Sigstatus.ToString());

                //SetUrl("usercpprofile.aspx");
                //SetMetaRefresh();
                //SetShowBackLink(true);
                //AddMsgLine("修改个人档案完毕");
                #endregion
            }
            else //注册新用户
            {
                #region 注册新用户
                //如果提交了用户注册信息...
                InviteCodeInfo inviteCode = null;

                string tmpUserName = postusername;
                //string email = email;
                string tmpBday = string.Empty;


                UserInfo userInfo = CreateUser(tmpUserName, email, tmpBday, mobile);

                #region 发送欢迎信息
                if (config.Welcomemsg == 1)
                {
                    // 收件箱
                    PrivateMessageInfo privatemessageinfo = new PrivateMessageInfo();
                    privatemessageinfo.Message = config.Welcomemsgtxt;
                    privatemessageinfo.Subject = "欢迎您的加入! (请勿回复本信息)";
                    privatemessageinfo.Msgto = userInfo.Username;
                    privatemessageinfo.Msgtoid = userInfo.Uid;
                    privatemessageinfo.Msgfrom = PrivateMessages.SystemUserName;
                    privatemessageinfo.Msgfromid = 0;
                    privatemessageinfo.New = 1;
                    privatemessageinfo.Postdatetime = Utils.GetDateTime();
                    privatemessageinfo.Folder = 0;
                    PrivateMessages.CreatePrivateMessage(privatemessageinfo, 0);
                }
                #endregion

                #region 发送同步数据给应用程序
                //发送同步数据给应用程序
                Sync.UserRegister(userInfo.Uid, userInfo.Username, userInfo.Password, "");

                Statistics.ReSetStatisticsCache();

                if (inviteCode != null)
                {
                    Invitation.UpdateInviteCodeSuccessCount(inviteCode.InviteId);
                    if (config.Regstatus == 3)
                    {
                        if (inviteCode.SuccessCount + 1 >= inviteCode.MaxCount)
                            Invitation.DeleteInviteCode(inviteCode.InviteId);
                    }
                }

                if (config.Regverify == 0)
                {
                    UserCredits.UpdateUserCredits(userInfo.Uid);
                    ForumUtils.WriteUserCookie(userInfo, -1, config.Passwordkey);
                    OnlineUsers.UpdateAction(olid, UserAction.Register.ActionID, 0, config.Onlinetimeout);
                }
                #endregion

                uid = Users.GetUserId(postusername);
                #endregion
            }
            #endregion


            if (uid != -1)
                Users.UpdateTrendStat(TrendType.Login);
            return uid > 0 ? Users.GetShortUserInfo(uid) : null;
        }
        #endregion

        #endregion


        /// <summary>
        /// BasePage类构造函数
        /// </summary>
        public PageBase()
        {
            if (recordPageView)
                PageViewStatistic(pagename);

            config = GeneralConfigs.GetConfig();
            if (SpacePluginProvider.GetInstance() == null)
                config.Enablespace = 0;
            if (AlbumPluginProvider.GetInstance() == null)
                config.Enablealbum = 0;
            if (MallPluginProvider.GetInstance() == null)
                config.Enablemall = 0;

            LoadUrlConfig();
            userid = Utils.StrToInt(ForumUtils.GetCookie("userid"), -1);


            //清空当前页面查询统计
#if DEBUG
            Discuz.Data.DbHelper.QueryCount = 0;
            Discuz.Data.DbHelper.QueryDetail = "";
#endif
            // 如果启用游客页面缓存，则对游客输出缓存页
            if (userid == -1 && config.Guestcachepagetimeout > 0 && GetUserCachePage(pagename))
                return;

            AddMetaInfo(config.Seokeywords, config.Seodescription, config.Seohead);

            if (config.Nocacheheaders == 1)
            {
                System.Web.HttpContext.Current.Response.BufferOutput = false;
                System.Web.HttpContext.Current.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
                System.Web.HttpContext.Current.Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
                System.Web.HttpContext.Current.Response.Expires = 0;
                System.Web.HttpContext.Current.Response.CacheControl = "no-cache";
                System.Web.HttpContext.Current.Response.Cache.SetNoStore();
            }

            //当为forumlist.aspx或forumindex.aspx,可能出现在线并发问题,这时系统会延时2秒
            if ((pagename != "forumlist.aspx") && (pagename != "forumindex.aspx"))
                oluserinfo = OnlineUsers.UpdateInfo(config.Passwordkey, config.Onlinetimeout);
            else
            {
                try
                {
                    oluserinfo = OnlineUsers.UpdateInfo(config.Passwordkey, config.Onlinetimeout);
                }
                catch
                {
                    System.Threading.Thread.Sleep(2000);
                    oluserinfo = OnlineUsers.UpdateInfo(config.Passwordkey, config.Onlinetimeout);
                }
            }

            if (config.PostTimeStorageMedia == 1 && Utils.GetCookie("lastposttime") != "")//如果最后发帖时间cookie不为空，则在此修改用户的该属性
                oluserinfo.Lastposttime = Utils.GetCookie("lastposttime");

            userid = oluserinfo.Userid;
            usergroupid = oluserinfo.Groupid;
            username = oluserinfo.Username;
            password = oluserinfo.Password;
            userkey = password.Length > 16 ? password.Substring(4, 8).Trim() : "";
            lastposttime = oluserinfo.Lastposttime;
            lastpostpmtime = oluserinfo.Lastpostpmtime;
            lastsearchtime = oluserinfo.Lastsearchtime;
            olid = oluserinfo.Olid;

            //确保头像可以取到
            if (userid > 0)
                useravatar = Avatars.GetAvatarUrl(userid, AvatarSize.Small);

            if (Utils.InArray(DNTRequest.GetString("selectedtemplateid"), Templates.GetValidTemplateIDList()))
                templateid = DNTRequest.GetInt("selectedtemplateid", 0);
            else if (Utils.InArray(Utils.GetCookie(Utils.GetTemplateCookieName()), Templates.GetValidTemplateIDList()))
                templateid = Utils.StrToInt(Utils.GetCookie(Utils.GetTemplateCookieName()), config.Templateid);

            if (templateid == 0)
                templateid = config.Templateid;

            pmsound = Utils.StrToInt(ForumUtils.GetCookie("pmsound"), 0);

            //已登录用户检测用户组状态,如果是禁言或禁止访问状态时间到期,则自动解禁
            if (usergroupid == 4 || usergroupid == 5)
            {

                //int groupExpiry = Users.GetShortUserInfo(userid).Groupexpiry;
                //if (groupExpiry != 0 && groupExpiry <= Utils.StrToInt(DateTime.Now.ToString("yyyyMMdd"), 0))
                //{
                //    //先改为第一个积分组
                //    usergroupid = 11;
                //    //usergroupinfo = UserGroups.GetUserGroupInfo(usergroupid);
                //    Users.UpdateUserGroup(userid, 11);
                //}

                ShortUserInfo userInfo = Users.GetShortUserInfo(userid);
                if (userInfo.Groupexpiry != 0 && userInfo.Groupexpiry <= Utils.StrToInt(DateTime.Now.ToString("yyyyMMdd"), 0))
                {
                    UserGroupInfo groupInfo = UserCredits.GetCreditsUserGroupId(userInfo.Credits);
                    usergroupid = groupInfo.Groupid != 0 ? groupInfo.Groupid : usergroupid;
                    Users.UpdateUserGroup(userid, usergroupid);
                }
            }

            usergroupinfo = UserGroups.GetUserGroupInfo(usergroupid);


            PublicLogin();


            // 取得用户权限id,1管理员,2超版,3版主,0普通组,-1特殊组
            useradminid = usergroupinfo.Radminid;
            string tips = ForumUtils.GetUserCreditsCookie(userid, usergroupinfo.Grouptitle);
            if (tips != "")
            {
                string[] userinfotipsList = tips.Split(',');//因为考虑到应用程序做单点登录时获取不到userinfotips，封装了此方法
                userinfotips = "<p><a class=\"drop\" onmouseover=\"showMenu(this.id);\" href=\"" + BaseConfigs.GetForumPath + "usercpcreditspay.aspx\" id=\"extcreditmenu\">" + userinfotipsList[0] + "</a> ";
                userinfotips += "<span class=\"pipe\">|</span>用户组: <a class=\"xi2\" id=\"g_upmine\" href=\"" + BaseConfigs.GetForumPath + "usercp.aspx\">" + userinfotipsList[1].Split(':')[1] + "</a></p>";
                userinfotips += "<ul id=\"extcreditmenu_menu\" class=\"p_pop\" style=\"display:none;\">";
                for (int i = 2; i < userinfotipsList.Length; i++)
                {
                    userinfotips += string.Format("<li><a> {0}</a></li>", userinfotipsList[i]);
                }
                userinfotips += "</ul>";
            }

            mainnavigation = Navs.GetNavigationString(userid, useradminid);
            subnavigation = Navs.GetSubNavigation();
            mainnavigationhassub = Navs.GetMainNavigationHasSub();
            // 如果论坛关闭且当前用户请求页面不是登录页面且用户非管理员, 则跳转至论坛关闭信息页
            if (config.Closed == 1 && pagename != "login.aspx" && pagename != "logout.aspx" && pagename != "register.aspx" && useradminid != 1)
            {
                ShowMessage(1);
                return;
            }

            if (!Utils.InArray(pagename, "attachment.aspx"))//加入附件页面判断减少性能消耗
                onlineusercount = (userid != -1) ? OnlineUsers.GetOnlineAllUserCount() : OnlineUsers.GetCacheOnlineAllUserCount();

            //校验用户是否可以访问论坛
            if (!ValidateUserPermission())
                return;

            //更新用户在线时长
            if (userid != -1 && !Utils.InArray(pagename, "attachment.aspx"))//加入附件页面判断减少性能消耗
                OnlineUsers.UpdateOnlineTime(config.Oltimespan, userid);
            TemplateInfo templateInfo = Templates.GetTemplateItem(templateid);
            templatepath = templateInfo.Directory;
            if (templateInfo.Templateurl.ToLower().StartsWith("http://"))
            {
                imagedir = templateInfo.Templateurl.TrimEnd('/') + "/images";
                cssdir = templateInfo.Templateurl.TrimEnd('/');
            }
            else
            {
                imagedir = forumpath + "templates/" + templateInfo.Directory + "/images";
                cssdir = forumpath + "templates/" + templateInfo.Directory;
            }
            if (EntLibConfigs.GetConfig() != null && !Utils.StrIsNullOrEmpty(EntLibConfigs.GetConfig().Topicidentifydir))
                topicidentifydir = EntLibConfigs.GetConfig().Topicidentifydir.TrimEnd('/');
            else
                topicidentifydir = forumpath + "images/identify";

            if (EntLibConfigs.GetConfig() != null && !Utils.StrIsNullOrEmpty(EntLibConfigs.GetConfig().Posticondir))
                posticondir = EntLibConfigs.GetConfig().Posticondir.TrimEnd('/');
            else
                posticondir = forumpath + "images/posticons";



            if (EntLibConfigs.GetConfig() != null && !Utils.StrIsNullOrEmpty(EntLibConfigs.GetConfig().Jsdir))
                jsdir = EntLibConfigs.GetConfig().Jsdir.TrimEnd('/');
            else
                jsdir = rooturl + "javascript";

            nowdate = Utils.GetDate();
            nowtime = Utils.GetTime();
            nowdatetime = Utils.GetDateTime();
            ispost = DNTRequest.IsPost();
            isget = DNTRequest.IsGet();
            link = "";
            script = "";

            templatelistboxoptions = Caches.GetTemplateListBoxOptionsCache();

            string originalTemplate = string.Format("<li><a href=\"###\" onclick=\"window.location.href='{0}showtemplate.aspx?templateid={1}'\">",
                                   "", BaseConfigs.GetForumPath, templateid);
            string newTemplate = string.Format("<li class=\"current\"><a href=\"###\" onclick=\"window.location.href='{0}showtemplate.aspx?templateid={1}'\">",
                                     BaseConfigs.GetForumPath, templateid);
            templatelistboxoptions = templatelistboxoptions.Replace(originalTemplate, newTemplate);

            isLoginCode = config.Seccodestatus.Contains("login.aspx");
            //当该页面设置了验证码检验，并且当前用户的用户组没有给予忽略验证码的权限，则isseccode=true;
            isseccode = Utils.InArray(pagename, config.Seccodestatus) && usergroupinfo.Ignoreseccode == 0;


            headerad = Advertisements.GetOneHeaderAd("", 0);
            footerad = Advertisements.GetOneFooterAd("", 0);

            //设定当前页面的显示样式
            if (config.Allowchangewidth == 0)
                Utils.WriteCookie("allowchangewidth", "");

            if (pagename != "website.aspx")
            {
                if (Utils.GetCookie("allowchangewidth") == "0" || (string.IsNullOrEmpty(Utils.GetCookie("allowchangewidth")) && config.Showwidthmode == 1))
                    isnarrowpage = true;
            }

            //校验验证码
            if (isseccode && ispost && !ValidateVerifyCode())
                return;

            newtopicminute = config.Viewnewtopicminute;
            m_starttick = DateTime.Now;

            ShowPage();

            m_processtime = DateTime.Now.Subtract(m_starttick).TotalMilliseconds / 1000;

            querycount = Discuz.Data.DbHelper.QueryCount;
            Discuz.Data.DbHelper.QueryCount = 0;

#if DEBUG
            querydetail = Discuz.Data.DbHelper.QueryDetail;
            Discuz.Data.DbHelper.QueryDetail = "";
#endif
        }

        #region 子方法
        /// <summary>
        /// 外部登录后使用论坛也登录
        /// </summary>
        private void PublicLogin()
        {
            #region 判断是否来自域名feipiao.cn
            //判断是否来自域名feipiao.cn
            //string host = HttpContext.Current.Request.UrlReferrer.Host;

            #region 测试主机头
            //string strPath = HttpContext.Current.Server.MapPath("~/Log");
            //strPath = strPath + "\\" + host + "_" + DateTime.Now.ToString().Replace(":", "") + ".txt";
            //StreamWriter fs = new StreamWriter(strPath, false, System.Text.Encoding.Default);
            //fs.Write("主机头:" + host + "参数：org=" + DNTRequest.GetString("org"));
            //fs.Close();
            #endregion
            //if (host.Trim() == "feipiao.cn" || host.Trim() == "www.feipiao.cn")
            //{
            //string org = DNTRequest.GetString("org");
            //if (org == "feipiao")//飞票官网网传递过来的参数
            //{
            //cookie跨域双向登录
            //未登录的话
            if (userid == -1)
            {
                HttpCookie hcLogin = CookiesHelper.GetCookie("dnt");
                string strPath = HttpContext.Current.Server.MapPath("~/Log");
                StreamWriter fs = null;
                if (hcLogin != null)
                {
                    //string json_logininfo = HttpUtility.UrlDecode(hcLogin.Value, Encoding.GetEncoding("utf-8"));
                    //Discuz.Entity.json_userinfo userinfo = (Discuz.Entity.json_userinfo)JavaScriptConvert.DeserializeObject(json_logininfo, typeof(Discuz.Entity.json_userinfo));
                    //if (userinfo != null)
                    //{
                    //论坛登录后获取cookie值
                    username = ForumUtils.GetCookie("username");
                    string mobile = ForumUtils.GetCookie("mobile");
                    string email = ForumUtils.GetCookie("email");
                    //php官网登录后跳转到asp.net论坛登录
                    if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(mobile))
                    {
                        string userinfo = HttpUtility.UrlDecode(hcLogin.Value, Encoding.GetEncoding("utf-8"));
                        string[] userinfos = userinfo.Split('&');
                        foreach (string item in userinfos)
                        {
                            string[] items = item.Split('=');
                            foreach (string subitem in items)
                            {
                                if (subitem == "username")
                                {
                                    username = items[1];
                                }
                                else if (subitem == "mobile")
                                {
                                    mobile = items[1];
                                }
                                else if (subitem == "email")
                                {
                                    email = items[1];
                                }
                            }
                        }
                    }
                    //}
                    //strPath = strPath + "\\" + "_" + DateTime.Now.ToString().Replace(":", "") + ".txt";
                    //fs = new StreamWriter(strPath, false, System.Text.Encoding.Default);
                    //fs.Write("用户名：" + username + "手机号：" + mobile + "邮箱：" + email);
                    //fs.Close();
                    #region 外部域名登录
                    //参数验证
                    if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(mobile))
                    {
                        userid = -1;
                    }
                    else
                    {
                        //正常获取用户信息
                        ShortUserInfo userInfo = GetShortUserInfo(username, mobile, email);
                        //通过官网接口获取用户信息

                        if (userInfo != null)
                        {
                            #region 当前用户所在用户组为"禁止访问"或"等待激活"时

                            if ((userInfo.Groupid == 4 || userInfo.Groupid == 5) && userInfo.Groupexpiry != 0 && userInfo.Groupexpiry <= Utils.StrToInt(DateTime.Now.ToString("yyyyMMdd"), 0))
                            {
                                //根据当前用户的积分获取对应积分用户组
                                UserGroupInfo groupInfo = UserCredits.GetCreditsUserGroupId(userInfo.Credits);
                                usergroupid = groupInfo.Groupid != 0 ? groupInfo.Groupid : usergroupid;
                                userInfo.Groupid = usergroupid;
                                Users.UpdateUserGroup(userInfo.Uid, usergroupid);
                            }

                            if (userInfo.Groupid == 5)// 5-禁止访问
                            {
                                AddErrLine("您所在的用户组，已经被禁止访问");
                                return;
                            }

                            if (userInfo.Groupid == 8)
                            {
                                if (config.Regverify == 1)
                                {
                                    needactiveuid = userInfo.Uid;
                                    email = userInfo.Email;
                                    timestamp = DateTime.Now.Ticks.ToString();
                                    authstr = Utils.MD5(string.Concat(userInfo.Password, config.Passwordkey, timestamp));
                                    AddMsgLine("请您到您的邮箱中点击激活链接来激活您的帐号");
                                }
                                else if (config.Regverify == 2)
                                    AddMsgLine("您需要等待一些时间, 待系统管理员审核您的帐户后才可登录使用");
                                else
                                    AddErrLine("抱歉, 您的用户身份尚未得到验证");

                                loginsubmit = false;
                                return;
                            }
                            #endregion

                            if (!Utils.StrIsNullOrEmpty(userInfo.Secques) && loginsubmit && Utils.StrIsNullOrEmpty(DNTRequest.GetString("loginauth")))
                            {
                                loginauth = DES.Encode(DNTRequest.GetString("password"), config.Passwordkey).Replace("+", "[");
                            }
                            else
                            {
                                //通过api整合的程序登录
                                if (APIConfigs.GetConfig().Enable)
                                    APILogin(APIConfigs.GetConfig());


                                AddMsgLine("登录成功, 返回登录前页面");

                                #region 无延迟更新在线信息和相关用户信息
                                ForumUtils.WriteUserCookie(userInfo.Uid, TypeConverter.StrToInt(DNTRequest.GetString("expires"), -1),
                config.Passwordkey, DNTRequest.GetInt("templateid", 0), DNTRequest.GetInt("loginmode", -1));
                                //oluserinfo = OnlineUsers.UpdateInfo(config.Passwordkey, config.Onlinetimeout);
                                oluserinfo = OnlineUsers.UpdateInfo(config.Passwordkey, config.Onlinetimeout, userInfo.Uid, "");
                                olid = oluserinfo.Olid;
                                username = username;
                                userid = userInfo.Uid;
                                usergroupinfo = UserGroups.GetUserGroupInfo(userInfo.Groupid);
                                useradminid = usergroupinfo.Radminid; // 根据用户组得到相关联的管理组id


                                OnlineUsers.UpdateAction(olid, UserAction.Login.ActionID, 0);
                                LoginLogs.DeleteLoginLog(DNTRequest.GetIP());
                                Users.UpdateUserCreditsAndVisit(userInfo.Uid, DNTRequest.GetIP());
                                #endregion

                                loginsubmit = false;
                                string reurl = Utils.UrlDecode(ForumUtils.GetReUrl());
                                SetUrl(reurl.IndexOf("register.aspx") < 0 ? reurl : forumpath + "index.aspx");

                                SetLeftMenuRefresh();

                                //同步登录到第三方应用
                                if (APIConfigs.GetConfig().Enable)
                                    AddMsgLine(Sync.GetLoginScript(userid, username));

                                if (!APIConfigs.GetConfig().Enable || !Sync.NeedAsyncLogin())
                                    MsgForward("login_succeed", true);
                            }
                        }
                        else
                        {
                            int errcount = LoginLogs.UpdateLoginLog(DNTRequest.GetIP(), true);
                            if (errcount > 5)
                                AddErrLine("您已经输入密码5次错误, 请15分钟后再试");
                            else
                                AddErrLine(string.Format("密码或安全提问第{0}次错误, 您最多有5次机会重试", errcount));
                        }
                        if (IsErr()) return;

                        ForumUtils.WriteUserCreditsCookie(userInfo, usergroupinfo.Grouptitle);
                    }
                    #endregion
                    //}
                }

            }
            //}
            //}
            #endregion
        }


        /// <summary>
        /// 输出Ajax验证码错误信息
        /// </summary>
        private static void ResponseAjaxVcodeError()
        {
            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.ContentType = "Text/XML";
            System.Web.HttpContext.Current.Response.Expires = 0;

            System.Web.HttpContext.Current.Response.Cache.SetNoStore();
            System.Text.StringBuilder xmlnode = new System.Text.StringBuilder();
            xmlnode.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n");
            xmlnode.Append("<error>验证码错误</error>");
            System.Web.HttpContext.Current.Response.Write(xmlnode.ToString());
            System.Web.HttpContext.Current.Response.End();
        }



        /// <summary>
        /// 设置页面定时转向
        /// </summary>
        public void SetMetaRefresh()
        {
            SetMetaRefresh(2, msgbox_url);
        }

        /// <summary>
        /// 设置页面定时转向
        /// </summary>
        /// <param name="sec">时间(秒)</param>
        public void SetMetaRefresh(int sec)
        {
            SetMetaRefresh(sec, msgbox_url);
        }

        /// <summary>
        /// 设置页面定时转向
        /// </summary>
        /// <param name="sec">时间(秒)</param>
        /// <param name="url">转向地址</param>
        public void SetMetaRefresh(int sec, string url)
        {
            if (infloat != 1)
            {
                meta = meta + "\r\n<meta http-equiv=\"refresh\" content=\"" + sec.ToString() + "; url=" + url + "\" />";
            }

        }

        /// <summary>
        /// 插入指定路径的CSS
        /// </summary>
        /// <param name="url">CSS路径</param>
        public void AddLinkCss(string url)
        {
            link = link + "\r\n<link href=\"" + url + "\" rel=\"stylesheet\" type=\"text/css\" />";//测试link
        }

        public void AddLinkRss(string url, string title)
        {
            link = link + "\r\n<link rel=\"alternate\" type=\"application/rss+xml\" title=\"" + Utils.RemoveHtml(title) + "\" href=\"" + url + "\" />";
        }


        /// <summary>
        /// 插入指定路径的CSS
        /// </summary>
        /// <param name="url">CSS路径</param>
        public void AddLinkCss(string url, string linkid)
        {
            link = link + "\r\n<link href=\"" + url + "\" rel=\"stylesheet\" type=\"text/css\" id=\"" + linkid + "\" />";
        }

        /// <summary>
        /// 插入脚本内容到页面head中
        /// </summary>
        /// <param name="scriptstr">不包括<script></script>的脚本主体字符串</param>
        public void AddScript(string scriptstr)
        {
            AddScript(scriptstr, "javascript");
        }

        /// <summary>
        /// 插入脚本内容到页面head中
        /// </summary>
        /// <param name="scriptstr">不包括<script>
        /// <param name="scripttype">脚本类型(值为：vbscript或javascript,默认为javascript)</param>
        public void AddScript(string scriptstr, string scripttype)
        {
            if (!scripttype.ToLower().Equals("vbscript") && !scripttype.ToLower().Equals("vbscript"))
            {
                scripttype = "javascript";
            }
            script = script + "\r\n<script type=\"text/" + scripttype + "\">" + scriptstr + "</script>";
        }

        /// <summary>
        /// 插入指定Meta
        /// </summary>
        /// <param name="metastr">Meta项</param>
        public void AddMeta(string metastr)
        {
            meta = meta + "\r\n<meta " + metastr + " />";
        }

        /// <summary>
        /// 更新页面Meta
        /// </summary>
        /// <param name="Seokeywords">关键词</param>
        /// <param name="Seodescription">说明</param>
        /// <param name="Seohead">其它增加项</param>
        public void UpdateMetaInfo(string Seokeywords, string Seodescription, string Seohead)
        {
            string[] metaArray = Utils.SplitString(meta, "\r\n");
            //设置为空,并在下面代码中进行重新赋值
            meta = "";
            foreach (string metaoption in metaArray)
            {
                //找出keywords关键字
                if (metaoption.ToLower().IndexOf("name=\"keywords\"") > 0)
                {
                    if (Seokeywords != null && Seokeywords.Trim() != "")
                    {
                        meta += "<meta name=\"keywords\" content=\"" + Utils.RemoveHtml(Seokeywords).Replace("\"", " ") + "\" />\r\n";
                        continue;
                    }
                }

                //找出description关键字
                if (metaoption.ToLower().IndexOf("name=\"description\"") > 0)
                {
                    if (Seodescription != null && Seodescription.Trim() != "")
                    {
                        meta += "<meta name=\"description\" content=\"" + Utils.RemoveHtml(Seodescription).Replace("\"", " ") + "\" />\r\n";
                        continue;
                    }
                }

                meta = meta + metaoption + "\r\n";
            }
        }


        /// <summary>
        /// 添加页面Meta信息
        /// </summary>
        /// <param name="Seokeywords">关键词</param>
        /// <param name="Seodescription">说明</param>
        /// <param name="Seohead">其它增加项</param>
        public void AddMetaInfo(string Seokeywords, string Seodescription, string Seohead)
        {
            if (Seokeywords != "")
            {
                meta = meta + "<meta name=\"keywords\" content=\"" + Utils.RemoveHtml(Seokeywords).Replace("\"", " ") + "\" />\r\n";
            }
            if (Seodescription != "")
            {
                meta = meta + "<meta name=\"description\" content=\"" + Utils.RemoveHtml(Seodescription).Replace("\"", " ") + "\" />\r\n";
            }
            meta = meta + Seohead;
        }

        /// <summary>
        /// 增加错误提示
        /// </summary>
        /// <param name="errinfo">错误提示信息</param>
        public void AddErrLine(string errinfo)
        {
            if (msgbox_text.Length == 0)
            {
                msgbox_text = msgbox_text + errinfo;
            }
            else
            {
                msgbox_text = msgbox_text + "<br />" + errinfo;
            }
            page_err++;
        }

        /// <summary>
        /// 增加提示信息
        /// </summary>
        /// <param name="strinfo">提示信息</param>
        public void AddMsgLine(string strinfo)
        {
            if (msgbox_text.Length == 0)
            {
                msgbox_text = msgbox_text + strinfo;
            }
            else
            {
                msgbox_text = msgbox_text + "<br />" + strinfo;
            }
        }

        /// <summary>
        /// 增加提示信息
        /// </summary>
        /// <param name="strinfo">提示信息</param>
        public void MsgForward(string forwardName, bool spJump)
        {
            if (config.Quickforward == 1 && infloat == 0 && Utils.InArray(forwardName, config.Msgforwardlist))
                System.Web.HttpContext.Current.Response.Redirect(spJump ? msgbox_url : forumpath + msgbox_url, true);
        }

        public void MsgForward(string forwardName)
        {
            MsgForward(forwardName, false);
        }



        /// <summary>
        /// 格式化字节格式
        /// </summary>
        /// <param name="byteStr"></param>
        /// <returns></returns>
        public string FormatBytes(double bytes)
        {
            if (bytes > 1073741824)
            {
                return ((Math.Round((bytes / 1073741824) * 100) / 100).ToString() + " G");
            }
            else if (bytes > 1048576)
            {
                return ((Math.Round((bytes / 1048576) * 100) / 100).ToString() + " M");
            }
            else if (bytes > 1024)
            {
                return ((Math.Round((bytes / 1024) * 100) / 100).ToString() + " K");
            }
            else
            {
                return (bytes.ToString() + " Bytes");
            }
        }

        /// <summary>
        /// 格式化字节格式
        /// </summary>
        /// <param name="byteStr"></param>
        /// <returns></returns>
        public string FormatBytes(string byteStr)
        {
            return FormatBytes((double)TypeConverter.StrToInt(byteStr));
        }


        /// <summary>
        /// 是否已经发生错误
        /// </summary>
        /// <returns>有错误则返回true, 无错误则返回false</returns>
        public bool IsErr()
        {
            return page_err > 0;
        }

        /// <summary>
        /// 设置要转向的url
        /// </summary>
        /// <param name="strurl">要转向的url</param>
        public void SetUrl(string strurl)
        {
            msgbox_url = strurl;
        }
        /// <summary>
        /// 设置回退链接的内容
        /// </summary>
        /// <param name="strback">回退链接的内容</param>
        public void SetBackLink(string strback)
        {
            msgbox_backlink = strback;
        }

        /// <summary>
        /// 设置是否显示回退链接
        /// </summary>
        /// <param name="link">要显示则为true, 否则为false</param>
        public void SetShowBackLink(bool link)
        {
            if (link)
            {
                msgbox_showbacklink = "true";
            }
            else
            {
                msgbox_showbacklink = "false";
            }
        }

        public void ShowMessage(byte mode)
        {
            ShowMessage("", mode);
        }

        public void ShowMessage(string hint, byte mode)
        {
            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.Write("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head><title>");
            string title;
            string body;
            switch (mode)
            {
                case 1:
                    title = "论坛已关闭";
                    body = config.Closedreason;
                    break;
                case 2:
                    title = "禁止访问";
                    body = hint;
                    break;
                default:
                    title = "提示";
                    body = hint;
                    break;
            }
            System.Web.HttpContext.Current.Response.Write(title);
            System.Web.HttpContext.Current.Response.Write(" - ");
            System.Web.HttpContext.Current.Response.Write(config.Forumtitle);
            System.Web.HttpContext.Current.Response.Write(" - Powered by Discuz!NT</title><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");
            System.Web.HttpContext.Current.Response.Write(meta);
            System.Web.HttpContext.Current.Response.Write("<style type=\"text/css\"><!-- body { margin: 20px; font-family: Tahoma, Verdana; font-size: 14px; color: #333333; background-color: #FFFFFF; }a {color: #1F4881;text-decoration: none;}--></style></head><body><div style=\"border: #cccccc solid 1px; padding: 20px; width: 500px; margin:auto\" align=\"center\">");
            System.Web.HttpContext.Current.Response.Write(body);
            System.Web.HttpContext.Current.Response.Write("</div><br /><br /><br /><div style=\"border: 0px; padding: 0px; width: 500px; margin:auto\"><strong>当前服务器时间:</strong> ");
            System.Web.HttpContext.Current.Response.Write(Utils.GetDateTime());
            System.Web.HttpContext.Current.Response.Write("<br /><strong>当前页面</strong> ");
            System.Web.HttpContext.Current.Response.Write(pagename);
            System.Web.HttpContext.Current.Response.Write("<br /><strong>可选择操作:</strong> ");
            if (userkey == "")
            {
                System.Web.HttpContext.Current.Response.Write("<a href=");
                System.Web.HttpContext.Current.Response.Write(forumpath);
                System.Web.HttpContext.Current.Response.Write("login.aspx>登录</a> | <a href=");
                System.Web.HttpContext.Current.Response.Write(forumpath);
                System.Web.HttpContext.Current.Response.Write("register.aspx>注册</a>");
            }
            else
            {
                System.Web.HttpContext.Current.Response.Write("<a href=\"logout.aspx?userkey=" + userkey + "\">退出</a>");
                if (useradminid == 1)
                {
                    System.Web.HttpContext.Current.Response.Write(" | <a href=\"logout.aspx?userkey=" + userkey + "\">系统管理</a>");
                }
            }
            System.Web.HttpContext.Current.Response.Write("</div></body></html>");
            System.Web.HttpContext.Current.ApplicationInstance.CompleteRequest();
            //System.Web.HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 得到当前页面的载入时间供模板中调用(单位:毫秒)
        /// </summary>
        /// <returns>当前页面的载入时间</returns>
        public double Processtime
        {
            get { return m_processtime; }
        }

        #endregion

        /// <summary>
        /// 页面处理虚方法
        /// </summary>
        protected virtual void ShowPage()
        {
            return;
        }
        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {

        }
        /// <summary>
        /// OnUnload事件处理
        /// </summary>
        /// <param name="e"></param>
        protected override void OnUnload(EventArgs e)
        {
            if (isguestcachepage == 1)
            {
                switch (pagename)
                {
                    case "index.aspx":
                        Discuz.Cache.DNTCache cache = Discuz.Cache.DNTCache.GetCacheService();
                        //Discuz.Cache.ICacheStrategy ics = new ForumCacheStrategy();
                        //ics.TimeOut = config.Guestcachepagetimeout * 60;
                        //cache.LoadCacheStrategy(ics);
                        string str = cache.RetrieveObject("/Forum/GuestCachePage/" + pagename) as string;
                        if (str == null && templateBuilder.Length > 1 && templateid == config.Templateid)
                        {
                            templateBuilder.Append("\r\n\r\n<!-- Discuz!NT CachedPage (Created: " + Utils.GetDateTime() + ") -->");
                            cache.AddObject("/Forum/GuestCachePage/" + pagename, templateBuilder.ToString());
                        }
                        //cache.LoadDefaultCacheStrategy();

                        break;

                    case "showtopic.aspx":
                        {
                            int topicid = DNTRequest.GetQueryInt("topicid", 0);
                            int pageid = DNTRequest.GetQueryInt("page", 1);
                            //参数数目为2或0表示当前页面可能为第一页帖子列表
                            if ((DNTRequest.GetParamCount() == 2 || DNTRequest.GetParamCount() == 3) && topicid > 0 && templateid == config.Templateid)
                            {
                                ForumUtils.CreateShowTopicCacheFile(topicid, pageid, templateBuilder.ToString());
                            }
                            break;
                        }
                    case "showforum.aspx":
                        {
                            int forumid = DNTRequest.GetQueryInt("forumid", 0);
                            int pageid = DNTRequest.GetQueryInt("page", 1);
                            //参数数目为2或0表示当前页面可能为第一页帖子列表
                            if ((DNTRequest.GetParamCount() == 2 || DNTRequest.GetParamCount() == 3) && forumid > 0 && templateid == config.Templateid)
                            {
                                ForumUtils.CreateShowForumCacheFile(forumid, pageid, templateBuilder.ToString());
                            }
                            break;
                        }
                    default:
                        //
                        break;
                }
            }

#if DEBUG
            else
            {
                System.Web.HttpContext.Current.Response.Clear();
                System.Web.HttpContext.Current.Response.Write(templateBuilder.Replace("</body>", "<div>注意: 以下为数据查询分析工具，正式站点使用请使用官方发布版本或自行Release编译。</div>" + querydetail + "</body>").ToString());
                System.Web.HttpContext.Current.Response.End();
            }
#endif
            base.OnUnload(e);
        }

        /// <summary>
        /// 控件初始化时计算执行时间
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            if (isguestcachepage == 1)
            {
                m_processtime = 0;
            }
            base.OnInit(e);
        }

        protected string aspxrewriteurl = "";

        #region aspxrewrite 配置

        /// <summary>
        /// 设置关于showforum页面链接的显示样式
        /// </summary>
        /// <param name="forumid"></param>
        /// <param name="pageid"></param>
        /// <returns></returns>
        protected string ShowForumAspxRewrite(string forumid, int pageid)
        {
            return ShowForumAspxRewrite(Utils.StrToInt(forumid, 0),
                                        pageid <= 0 ? 0 : pageid);
        }


        protected string ShowForumAspxRewrite(int forumid, int pageid)
        {
            return Urls.ShowForumAspxRewrite(forumid, pageid);
        }

        protected string ShowForumAspxRewrite(string pathlist, int forumid, int pageid)
        {
            return Urls.ShowForumAspxRewrite(pathlist, forumid, pageid);
        }

        protected string ShowForumAspxRewrite(int forumid, int pageid, string rewritename)
        {
            return Urls.ShowForumAspxRewrite(forumid, pageid, rewritename);
        }

        /// <summary>
        /// 设置关于showtopic页面链接的显示样式
        /// </summary>
        /// <param name="forumid"></param>
        /// <param name="pageid"></param>
        /// <returns></returns>
        protected string ShowTopicAspxRewrite(string topicid, int pageid)
        {
            return ShowTopicAspxRewrite(Utils.StrToInt(topicid, 0),
                                        pageid <= 0 ? 0 : pageid);
        }

        protected string ShowTopicAspxRewrite(int topicid, int pageid)
        {
            return Urls.ShowTopicAspxRewrite(topicid, pageid);
        }

        protected string ShowDebateAspxRewrite(string topicid)
        {
            return ShowDebateAspxRewrite(Utils.StrToInt(topicid, 0));
        }

        protected string ShowDebateAspxRewrite(int topicid)
        {
            return Urls.ShowDebateAspxRewrite(topicid);
        }

        /// <summary>
        /// 设置关于showbonus页面链接的显示样式
        /// </summary>
        /// <param name="forumid"></param>
        /// <param name="pageid"></param>
        /// <returns></returns>
        protected string ShowBonusAspxRewrite(string topicid, int pageid)
        {
            return ShowBonusAspxRewrite(Utils.StrToInt(topicid, 0),
                                        pageid <= 0 ? 0 : pageid);
        }

        /// <summary>
        /// 设置关于showbonus页面链接的显示样式
        /// </summary>
        /// <param name="topicid"></param>
        /// <param name="pageid"></param>
        /// <returns></returns>
        protected string ShowBonusAspxRewrite(int topicid, int pageid)
        {
            return Urls.ShowBonusAspxRewrite(topicid, pageid);
        }


        protected string UserInfoAspxRewrite(int userid)
        {
            return Urls.UserInfoAspxRewrite(userid);
        }

        /// <summary>
        /// 设置关于userinfo页面链接的显示样式
        /// </summary>
        /// <param name="forumid"></param>
        /// <param name="pageid"></param>
        /// <returns></returns>
        protected string UserInfoAspxRewrite(string userid)
        {
            return UserInfoAspxRewrite(Utils.StrToInt(userid, 0));
        }

        protected string RssAspxRewrite(int forumid)
        {
            return Urls.RssAspxRewrite(forumid);
        }

        /// <summary>
        /// 设置关于userinfo页面链接的显示样式
        /// </summary>
        /// <param name="forumid"></param>
        /// <param name="pageid"></param>
        /// <returns></returns>
        protected string RssAspxRewrite(string forumid)
        {
            return RssAspxRewrite(Utils.StrToInt(forumid, 0));
        }

        /// <summary>
        /// 设置关于showgoods页面链接的显示样式
        /// </summary>
        /// <param name="forumid"></param>
        /// <param name="pageid"></param>
        /// <returns></returns>
        protected string ShowGoodsAspxRewrite(string goodsid)
        {
            return ShowGoodsAspxRewrite(Utils.StrToInt(goodsid, 0));
        }

        protected string ShowGoodsAspxRewrite(int goodsid)
        {
            return Urls.ShowGoodsAspxRewrite(goodsid);
        }

        /// <summary>
        /// 设置关于showgoods页面链接的显示样式
        /// </summary>
        /// <param name="forumid"></param>
        /// <param name="pageid"></param>
        /// <returns></returns>
        protected string ShowGoodsListAspxRewrite(string categoryid, int pageid)
        {
            return ShowGoodsListAspxRewrite(Utils.StrToInt(categoryid, 0),
                                        pageid <= 0 ? 0 : pageid);
        }

        protected string ShowGoodsListAspxRewrite(int categoryid, int pageid)
        {
            return Urls.ShowGoodsListAspxRewrite(categoryid, pageid);
        }
        #endregion

    }
}
