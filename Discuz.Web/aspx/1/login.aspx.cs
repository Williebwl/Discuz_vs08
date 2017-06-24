using System;
using System.Data;
using System.Text;

using Discuz.Common;
using Discuz.Forum;
using Discuz.Config;
using Discuz.Entity;
using Discuz.Web.UI;
using Discuz.Plugin.PasswordMode;
using Newtonsoft.Json;
using System.Web;
using System.IO;

namespace Discuz.Web
{
    /// <summary>
    /// 登录
    /// </summary>
    public class login : PageBase
    {
        #region 页面变量
        /// <summary>
        /// 登录所使用的用户名
        /// </summary>
        public string postusername = Utils.UrlDecode(DNTRequest.GetString("postusername")).Trim();
        /// <summary>
        /// 登陆时的密码验证信息
        /// </summary>
        public string loginauth = DNTRequest.GetString("loginauth");
        /// <summary>
        /// 登陆时提交的密码
        /// </summary>
        public string postpassword = "";
        /// <summary>
        /// 登陆成功后跳转的链接
        /// </summary>
        public string referer = Utils.HtmlEncode(DNTRequest.GetString("referer"));
        /// <summary>
        /// 是否跨页面提交
        /// </summary>
        public bool loginsubmit = DNTRequest.GetString("loginsubmit") == "true" ? true : false;
        /// <summary>
        /// 重设Email的加密校验，确保是该用户在当前页面操作的
        /// </summary>
        public string authstr = "";
        /// <summary>
        /// 需要激活的用户id
        /// </summary>
        public int needactiveuid = -1;
        /// <summary>
        /// 重置的Email信息的有效时间
        /// </summary>
        public string timestamp = "";
        /// <summary>
        /// 需要激活的用户Email
        /// </summary>
        public string email = "";

        public int inapi = 0;

        #endregion

        protected override void ShowPage()
        {
            pagetitle = "用户登录";
            inapi = DNTRequest.GetInt("inapi", 0);
            if (userid != -1)
            {
                SetUrl(BaseConfigs.GetForumPath);
                AddMsgLine("您已经登录，无须重复登录");
                ispost = true;
                SetLeftMenuRefresh();

                if (APIConfigs.GetConfig().Enable)
                    APILogin(APIConfigs.GetConfig());
            }

            if (LoginLogs.UpdateLoginLog(DNTRequest.GetIP(), false) >= 5)
            {
                AddErrLine("您已经多次输入密码错误, 请15分钟后再登录");
                loginsubmit = false;
                return;
            }

            SetReUrl();

            //如果提交...
            if (DNTRequest.IsPost())
            {
                SetBackLink();

                //如果没输入验证码就要求用户填写
                if (isseccode && DNTRequest.GetString("vcode") == "")
                {
                    postusername = DNTRequest.GetString("username");
                    loginauth = DES.Encode(DNTRequest.GetString("password"), config.Passwordkey).Replace("+", "[");
                    loginsubmit = true;
                    return;
                }

                if (Utils.StrIsNullOrEmpty(DNTRequest.GetString("username"))
                    && Utils.StrIsNullOrEmpty(DNTRequest.GetString("password"))
                    && Utils.StrIsNullOrEmpty(DNTRequest.GetString("loginauth"))
                   )
                {
                    AddErrLine("用户名不能为空");
                    AddErrLine("密码不能为空");
                    return;
                }

                if (config.Emaillogin == 1 && Utils.IsValidEmail(DNTRequest.GetString("username")))//允许邮箱登录
                {
                    DataTable dt = Users.GetUserInfoByEmail(DNTRequest.GetString("username"));
                    if (dt.Rows.Count == 0)
                    {
                        AddErrLine("用户不存在");
                        return;
                    }
                    if (dt.Rows.Count > 1)
                    {
                        AddErrLine("您所使用Email不唯一，请使用用户名登陆");
                        return;
                    }
                    if (dt.Rows.Count == 1)
                    {
                        postusername = dt.Rows[0]["username"].ToString();
                    }
                }
                //json字符串反序列化成实体对象
                Discuz.Entity.feipiao_userinfo_response feipiaoXmlModel = null;

                if (config.Emaillogin == 0)//禁止邮箱登录
                {
                    postusername = DNTRequest.GetString("username");
                    postpassword = DNTRequest.GetString("password");

                    #region 测试主机头
                    //string strPath = HttpContext.Current.Server.MapPath("~/Log");
                    //strPath = strPath + "\\" + "FeiPiao_UserLoginAPI" + "_" + DateTime.Now.ToString().Replace(":", "") + ".txt";
                    //StreamWriter fs = new StreamWriter(strPath, false, System.Text.Encoding.Default);
                    //fs.Write("API地址" + Discuz.Common.ConfigOperator.ConfigReadValue("FeiPiao_UserLoginAPI"));
                    //fs.Close();
                    #endregion

                    #region 调用官网接口登陆
                    //调用官网接口登陆
                    string htmlText = Discuz.Common.SendData.Intsance.SendRequest(Discuz.Common.ConfigOperator.ConfigReadValue("FeiPiao_UserLoginAPI"), "UTF-8", "action=act_login&login_type=myfeipiao&username=" + postusername + "&password=" + postpassword);

                    htmlText = HttpUtility.UrlDecode(htmlText, Encoding.GetEncoding("utf-8"));
                    if (!string.IsNullOrEmpty(htmlText))
                    {
                        htmlText = htmlText.Substring(htmlText.IndexOf("_myfeipiao_") + 11);
                        feipiaoXmlModel = (Discuz.Entity.feipiao_userinfo_response)JavaScriptConvert.DeserializeObject(htmlText, typeof(Discuz.Entity.feipiao_userinfo_response));
                        //官网登陆成功
                        if (feipiaoXmlModel.result.id == "0000")
                        {

                        }
                        else
                        {
                            AddErrLine("用户和密码不匹配");
                        }
                    }
                    #endregion
                }

                if (IsErr()) return;

                //正常获取用户信息
                ShortUserInfo userInfo = GetShortUserInfo(feipiaoXmlModel.userinfo.UserAccount, postpassword, feipiaoXmlModel.userinfo.Mobile, feipiaoXmlModel.userinfo.Email);
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
                        username = feipiaoXmlModel.userinfo.UserAccount;
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
        }

        /// <summary>
        /// 设置BackLink
        /// </summary>
        private void SetBackLink()
        {
            StringBuilder builder = new StringBuilder();
            foreach (string key in System.Web.HttpContext.Current.Request.QueryString.AllKeys)
            {
                //if (key != "postusername")
                if (!string.IsNullOrEmpty(key) && !Utils.InArray(key, "postusername"))
                    builder.AppendFormat("&{0}={1}", key, DNTRequest.GetQueryString(key));
            }
            question = DNTRequest.GetFormInt("question", 0);
            if (question > 0)
                builder.AppendFormat("&question={0}", question);
            base.SetBackLink("login.aspx?postusername=" + Utils.UrlEncode(DNTRequest.GetString("username")) + builder);
        }

        /// <summary>
        /// 获取用户id
        /// </summary>
        /// <returns></returns>
        private ShortUserInfo GetShortUserInfo(string postusername, string postpassword, string mobile, string email)
        {
            //postpassword = !Utils.StrIsNullOrEmpty(loginauth) ?
            //        DES.Decode(loginauth.Replace("[", "+"), config.Passwordkey) :
            //        DNTRequest.GetString("password");

            //postusername = Utils.StrIsNullOrEmpty(postusername) ? DNTRequest.GetString("username") : postusername;

            int uid = -1;
            switch (config.Passwordmode)
            {
                case 1://动网兼容模式
                    {
                        if (config.Secques == 1 && (!Utils.StrIsNullOrEmpty(loginauth) || !loginsubmit))
                            uid = Users.CheckDvBbsPasswordAndSecques(postusername, postpassword, DNTRequest.GetFormInt("question", 0), DNTRequest.GetString("answer"));
                        else
                            uid = Users.CheckDvBbsPassword(postusername, postpassword);
                        break;
                    }
                case 0://默认模式
                    {
                        if (config.Secques == 1 && (!Utils.StrIsNullOrEmpty(loginauth) || !loginsubmit))
                        {
                            uid = Users.CheckPasswordAndSecques(postusername, postpassword, true, DNTRequest.GetFormInt("question", 0), DNTRequest.GetString("answer"));
                        }
                        else
                        {

                            #region 原始登录
                            //原始的登录
                            // uid = Users.CheckPassword(postusername, postpassword, true); 
                            #endregion

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


                                if (CheckModified(oldUserInfo, userInfo))
                                {
                                    Users.UpdateUserProfile(userInfo);
                                    Sync.UpdateProfile(userInfo.Uid, userInfo.Username, "");
                                }
                                OnlineUsers.DeleteUserByUid(userid);    //删除在线表中的信息，使之重建该用户在线表信息
                                //ManyouApplications.AddUserLog(userid, UserLogActionEnum.Update);

                                ForumUtils.WriteCookie("sigstatus", userInfo.Sigstatus.ToString());

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

                        }
                        break;
                    }
                default: //第三方加密验证模式
                    {
                        return (ShortUserInfo)Users.CheckThirdPartPassword(postusername, postpassword, DNTRequest.GetFormInt("question", 0), DNTRequest.GetString("answer"));
                    }
            }
            if (uid != -1)
            {
                Users.UpdateTrendStat(TrendType.Login);
            }
            return uid > 0 ? Users.GetShortUserInfo(uid) : null;
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

            //第三方加密验证模式
            if (config.Passwordmode > 1 && PasswordModeProvider.GetInstance() != null)
            {
                userinfo.Uid = PasswordModeProvider.GetInstance().CreateUserInfo(userinfo);
            }
            else
            {
                userinfo.Password = Utils.MD5(userinfo.Password);
                userinfo.Uid = Users.CreateUser(userinfo);
            }
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

        /// <summary>
        /// 设置reurl
        /// </summary>
        private void SetReUrl()
        {
            //未提交或跨页提交时
            if (!DNTRequest.IsPost() || referer != "")
            {
                string r = "";
                if (referer != "")
                    r = DNTRequest.GetUrlReferrer();
                else
                {
                    if ((DNTRequest.GetUrlReferrer() == "") || (DNTRequest.GetUrlReferrer().IndexOf("login") > -1) || DNTRequest.GetUrlReferrer().IndexOf("logout") > -1)
                        r = "index.aspx";
                    else
                        r = DNTRequest.GetUrlReferrer();
                }
                Utils.WriteCookie("reurl", (DNTRequest.GetQueryString("reurl") == "" || DNTRequest.GetQueryString("reurl").IndexOf("login.aspx") > -1) ? r : DNTRequest.GetQueryString("reurl"));
            }
        }

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
    }
}