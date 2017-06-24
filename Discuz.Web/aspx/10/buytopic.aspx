<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Discuz.Web.buytopic" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Discuz.Common" %>
<%@ Import namespace="Discuz.Forum" %>
<%@ Import namespace="Discuz.Entity" %>
<%@ Import namespace="Discuz.Config" %>

<script runat="server">
override protected void OnInit(EventArgs e)
{

	/* 
		This page was created by Discuz!NT Template Engine at 2013-3-17 15:46:26.
		本页面代码由Discuz!NT模板引擎生成于 2013-3-17 15:46:26. 
	*/

	base.OnInit(e);

	templateBuilder.Capacity = 220000;



	if (infloat!=1)
	{

	templateBuilder.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n    ");
	if (pagetitle=="首页")
	{

	templateBuilder.Append("\r\n    <title>");
	templateBuilder.Append(config.Forumtitle.ToString().Trim());
	templateBuilder.Append(" ");
	templateBuilder.Append(config.Seotitle.ToString().Trim());
	templateBuilder.Append("</title>\r\n    ");
	}
	else
	{

	templateBuilder.Append("\r\n    <title>");
	templateBuilder.Append(pagetitle.ToString());
	templateBuilder.Append(" - ");
	templateBuilder.Append(config.Forumtitle.ToString().Trim());
	templateBuilder.Append(" ");
	templateBuilder.Append(config.Seotitle.ToString().Trim());
	templateBuilder.Append(" </title>\r\n    ");
	}	//end if

	templateBuilder.Append("\r\n    ");
	templateBuilder.Append(meta.ToString());
	templateBuilder.Append("\r\n    <!--<meta name=\"generator\" content=\"Discuz!NT 3.6.601\" />\r\n    <meta name=\"author\" content=\"Discuz!NT Team and Comsenz UI Team\" />\r\n    <meta name=\"copyright\" content=\"2001-2011 Comsenz Inc.\" />-->\r\n    <meta http-equiv=\"x-ua-compatible\" content=\"ie=7\" />\r\n    <link rel=\"icon\" href=\"");
	templateBuilder.Append(forumurl.ToString());
	templateBuilder.Append("favicon.ico\" type=\"image/x-icon\" />\r\n    <link rel=\"shortcut icon\" href=\"");
	templateBuilder.Append(forumurl.ToString());
	templateBuilder.Append("favicon.ico\" type=\"image/x-icon\" />\r\n    ");
	if (pagename!="website.aspx")
	{

	templateBuilder.Append("\r\n    <link rel=\"stylesheet\" href=\"");
	templateBuilder.Append(cssdir.ToString());
	templateBuilder.Append("/dnt.css\" type=\"text/css\" media=\"all\" />\r\n    ");
	}	//end if

	templateBuilder.Append("\r\n    <link rel=\"stylesheet\" href=\"");
	templateBuilder.Append(cssdir.ToString());
	templateBuilder.Append("/float.css\" type=\"text/css\" />\r\n    ");
	if (isnarrowpage)
	{

	templateBuilder.Append("\r\n    <link type=\"text/css\" rel=\"stylesheet\" href=\"");
	templateBuilder.Append(cssdir.ToString());
	templateBuilder.Append("/widthauto.css\" id=\"css_widthauto\" />\r\n    ");
	}	//end if

	templateBuilder.Append("\r\n    ");
	templateBuilder.Append(link.ToString());
	templateBuilder.Append("\r\n\r\n    <script type=\"text/javascript\">\r\n        var creditnotice='");
	templateBuilder.Append(Scoresets.GetValidScoreNameAndId().ToString().Trim());
	templateBuilder.Append("';	\r\n        var forumpath = \"");
	templateBuilder.Append(forumpath.ToString());
	templateBuilder.Append("\";\r\n    </");
	templateBuilder.Append("script>\r\n\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append(config.Jqueryurl.ToString().Trim());
	templateBuilder.Append("\"></");
	templateBuilder.Append("script>\r\n\r\n    <script type=\"text/javascript\">jQuery.noConflict();</");
	templateBuilder.Append("script>\r\n\r\n    <!--新增头部开始-->\r\n    <link href=\"");
	templateBuilder.Append(cssdir.ToString());
	templateBuilder.Append("/top-nav.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n\r\n    <script src=\"");
	templateBuilder.Append(jsdir.ToString());
	templateBuilder.Append("/template_top.js?t=20130312.js\" type=\"text/javascript\"></");
	templateBuilder.Append("script>\r\n\r\n    <!--[if IE 6]>\r\n    <script type=\"text/javascript\" src=\"http://www.feipiao.cn/js/DD_belatedPNG.js\" ></");
	templateBuilder.Append("script>\r\n    <script type=\"text/javascript\">\r\n    DD_belatedPNG.fix('.iu02,.link01,.link02,.link03,.link04');\r\n    </");
	templateBuilder.Append("script>\r\n    <![endif]-->\r\n    <!--新增头部结束-->\r\n\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append(jsdir.ToString());
	templateBuilder.Append("/common.js?t=20130305.js\"></");
	templateBuilder.Append("script>\r\n\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append(jsdir.ToString());
	templateBuilder.Append("/template_report.js\"></");
	templateBuilder.Append("script>\r\n\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append(jsdir.ToString());
	templateBuilder.Append("/template_utils.js\"></");
	templateBuilder.Append("script>\r\n\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append(jsdir.ToString());
	templateBuilder.Append("/ajax.js\"></");
	templateBuilder.Append("script>\r\n\r\n    <script type=\"text/javascript\">\r\n	    var aspxrewrite = ");
	templateBuilder.Append(config.Aspxrewrite.ToString().Trim());
	templateBuilder.Append(";\r\n	    var IMGDIR = '");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("';\r\n        var disallowfloat = '");
	templateBuilder.Append(config.Disallowfloatwin.ToString().Trim());
	templateBuilder.Append("';\r\n	    var rooturl=\"");
	templateBuilder.Append(rooturl.ToString());
	templateBuilder.Append("\";\r\n	    var imagemaxwidth='");
	templateBuilder.Append(Templates.GetTemplateWidth(templatepath).ToString().Trim());
	templateBuilder.Append("';\r\n	    var cssdir='");
	templateBuilder.Append(cssdir.ToString());
	templateBuilder.Append("';\r\n    </");
	templateBuilder.Append("script>\r\n\r\n    ");
	templateBuilder.Append(script.ToString());
	templateBuilder.Append("\r\n</head>\r\n");

	templateBuilder.Append("\r\n<body onkeydown=\"if(event.keyCode==27) return false;\">\r\n    ");
	templateBuilder.Append("<div class=\"top\">\r\n    <div id=\"box\">\r\n        <div class=\"fl1 logo\">\r\n            <a href=\"http://www.feipiao.cn\">\r\n                <img src=\"http://www.feipiao.cn/template/feipiao/image/logo.jpg\" /></a></div>\r\n        <div class=\"fl1 logoad\">\r\n        </div>\r\n        <dl class=\"weibo fl2\">\r\n            <dd class=\"link01\" style=\"margin-left: 32px;\">\r\n                <a href=\"http://www.feipiao.cn/index.php?act=invite\">邀请好友</a></dd>\r\n            <dd class=\"link02\">\r\n                <a href=\"http://www.feipiao.cn/index.php?act=subscribe\">有奖定制</a></dd>\r\n            <dd class=\"link03\">\r\n                <a href=\"#\" onclick=\"AddToFavorite();\">加入收藏</a></dd>\r\n            <dd class=\"link04\">\r\n                <iframe width=\"63\" height=\"24\" frameborder=\"0\" allowtransparency=\"true\" marginwidth=\"0\"\r\n                    marginheight=\"0\" scrolling=\"no\" border=\"0\" src=\"http://widget.weibo.com/relationship/followbutton.php?language=zh_cn&width=63&height=24&uid=2088419243&style=1&btn=red&dpc=1\">\r\n                </iframe>\r\n            </dd>\r\n            <dt>\r\n                <form method=\"get\" action=\"http://www.feipiao.cn/index.php\">\r\n                <input name=\"button\" id=\"button\" type=\"submit\" value=\"\" class=\"iu02\">\r\n                <input name=\"serch\" type=\"text\" id=\"txt_topsearch\" value=\"景区或酒店名称\" style=\"color: #CCC;\"\r\n                    onfocus=\"SearchFocus();\" onblur=\"SearchBlur();\" class=\"iku\">\r\n                <input type=\"hidden\" name=\"act\" value=\"group_list\">\r\n                </form>\r\n            </dt>\r\n        </dl>\r\n        <div class=\"clear\">\r\n        </div>\r\n        <ul class=\"nav\">\r\n            <li class=\"d_out1\" onmouseover=\"this.className='d_over1'\" onmouseout=\"this.className='d_out1'\">\r\n                <dl>\r\n                    <dt><a href=\"http://www.feipiao.cn/index.php\">首&nbsp;&nbsp;页</a></dt>\r\n                </dl>\r\n            </li>\r\n            <li class=\"d_out2\" onmouseover=\"this.className='d_over2'\" onmouseout=\"this.className='d_out2'\">\r\n                <dl>\r\n                    <dt class=\"home02\"><a href=\"http://www.feipiao.cn/index.php?act=group_list&type=today_sales\">\r\n                        限时特价</a></dt>\r\n                    <dd class=\"nav_xizi\">\r\n                        <a href=\"http://www.feipiao.cn/index.php?act=group_list&type=today_sales\">今日特价</a></dd>\r\n                    <dd>\r\n                        <a href=\"http://www.feipiao.cn/index.php?act=group_list&type=before_sales\">往期特价</a></dd>\r\n                </dl>\r\n            </li>\r\n            <li class=\"d_out3\" onmouseover=\"this.className='d_over3'\" onmouseout=\"this.className='d_out3'\">\r\n                <dl>\r\n                    <dt class=\"home03\"><a href=\"http://www.feipiao.cn/index.php?act=freew\">自由行</a></dt>\r\n                    <dd class=\"nav_xizi\">\r\n                        <a href=\"http://www.feipiao.cn/index.php?act=freew&type=free_list&free_type=rim\">周边游</a></dd>\r\n                    <dd>\r\n                        <a href=\"http://www.feipiao.cn/index.php?act=freew&type=free_list&free_type=inland\">\r\n                            国内游</a></dd>\r\n                </dl>\r\n            </li>\r\n            <li class=\"d_out4\" onmouseover=\"this.className='d_over4'\" onmouseout=\"this.className='d_out4'\">\r\n                <dl>\r\n                    <dt class=\"home04\"><a href=\"http://bbs.feipiao.cn/\" target=\"_blank\">\r\n                        驴友论坛</a></dt>\r\n                    <dd class=\"nav_xizi\">\r\n                        <a href=\"http://bbs.feipiao.cn/showforum-13.aspx\" target=\"_blank\">\r\n                            有奖活动</a><span style=\"padding-left: 15px;\"><a href=\"http://bbs.feipiao.cn/showforum-8.aspx\"\r\n                                target=\"_blank\">攻略游记</a></span></dd>\r\n                    <dd>\r\n                        <a href=\"http://bbs.feipiao.cn/showforum-9.aspx\" target=\"_blank\">\r\n                            户外美食</a><span style=\"padding-left: 15px;\"><a href=\"http://bbs.feipiao.cn/showforum-6.aspx\"\r\n                                target=\"_blank\">晒单足迹</a></span></dd>\r\n                </dl>\r\n            </li>\r\n            <li class=\"d_out5\" onmouseover=\"this.className='d_over5'\" onmouseout=\"this.className='d_out5'\">\r\n                <dl>\r\n                    <dt class=\"home05\"><a href=\"http://www.feipiao.cn/index.php?act=help&big_id=106&id=56\">\r\n                        品牌介绍</a></dt>\r\n                    <dd class=\"nav_xizi\">\r\n                        <a href=\"http://www.feipiao.cn/index.php?act=help&big_id=106&id=56\">关于飞票</a></dd>\r\n                    <dd>\r\n                        <a href=\"http://www.feipiao.cn/index.php?act=help&big_id=107&id=62\">商务合作</a></dd>\r\n                </dl>\r\n            </li>\r\n            <li class=\"d_out6\" onmouseover=\"this.className='d_over6'\" onmouseout=\"this.className='d_out6'\">\r\n                <dl>\r\n                    <dt class=\"home06\"><a href=\"http://www.feipiao.cn/index.php?act=help\">帮助中心</a></dt>\r\n                </dl>\r\n            </li>\r\n        </ul>\r\n        <ul class=\"gwc fl1\">\r\n            ");
	if (userid==-1)
	{

	templateBuilder.Append("\r\n            <li><a href=\"http://www.feipiao.cn/index.php?act=login\">登录</a></li>\r\n            <li>|</li>\r\n            <li><a href=\"http://www.feipiao.cn/index.php?act=signup\">注册</a></li>\r\n            ");
	}
	else
	{

	templateBuilder.Append("\r\n            <li><a href=\"");
	templateBuilder.Append(forumpath.ToString());
	templateBuilder.Append("userinfo.aspx?userid=");
	templateBuilder.Append(userid.ToString());
	templateBuilder.Append("\">");
	templateBuilder.Append(username.ToString());
	templateBuilder.Append("</a></li>\r\n            ");
	if (useradminid==1)
	{

	templateBuilder.Append("\r\n            <li>|</li>\r\n            <li><a href=\"");
	templateBuilder.Append(forumpath.ToString());
	templateBuilder.Append("admin/index.aspx\" target=\"_blank\">系统设置</a> </li>\r\n            ");
	}	//end if

	templateBuilder.Append("\r\n            <li>|</li>\r\n            <li><a href=\"");
	templateBuilder.Append(forumpath.ToString());
	templateBuilder.Append("logout.aspx?userkey=");
	templateBuilder.Append(userkey.ToString());
	templateBuilder.Append("\">退出</a></li>\r\n            ");
	}	//end if

	templateBuilder.Append("\r\n        </ul>\r\n        <div class=\" clear\">\r\n        </div>\r\n    </div>\r\n</div>\r\n");

	templateBuilder.Append("\r\n    <div id=\"append_parent\">\r\n    </div>\r\n    <div id=\"ajaxwaitid\">\r\n    </div>\r\n    ");
	if (headerad!="")
	{

	templateBuilder.Append("\r\n    <div id=\"ad_headerbanner\">\r\n        ");
	templateBuilder.Append(headerad.ToString());
	templateBuilder.Append("</div>\r\n    ");
	}	//end if

	templateBuilder.Append("\r\n    <div id=\"hd\" style=\"display: none;\">\r\n        <div class=\"wrap\">\r\n            <div class=\"head cl\">\r\n                <h2>\r\n                    <a href=\"");
	templateBuilder.Append(forumpath.ToString());
	templateBuilder.Append("index.aspx\" title=\"");
	templateBuilder.Append(config.Forumtitle.ToString().Trim());
	templateBuilder.Append("\">\r\n                        <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/logo.png\" alt=\"");
	templateBuilder.Append(config.Forumtitle.ToString().Trim());
	templateBuilder.Append("\" /></a></h2>\r\n                ");
	if (userid==-1)
	{


	if (pagename!="login.aspx"&&pagename!="register.aspx")
	{

	templateBuilder.Append("\r\n                <form onsubmit=\"if ($('ls_username').value == '' || $('ls_username').value == '用户名/Email') showWindow('login', '");
	templateBuilder.Append(rooturl.ToString());
	templateBuilder.Append("login.aspx');hideWindow('register');return\"\r\n                action=\"");
	templateBuilder.Append(rooturl.ToString());
	templateBuilder.Append("login.aspx?referer=");
	templateBuilder.Append(pagename.ToString());
	templateBuilder.Append("\" id=\"lsform\" autocomplete=\"off\" method=\"post\">\r\n                <div class=\"fastlg c1\">\r\n                    <div class=\"y pns\">\r\n                        <p>\r\n                            <label for=\"ls_username\">\r\n                                帐号</label>\r\n                            <input type=\"text\" tabindex=\"901\" value=\"用户名/Email\" id=\"ls_username\" name=\"username\"\r\n                                class=\"txt\" onblur=\"if(this.value == '') this.value = '用户名/Email';\" onfocus=\"if(this.value == '用户名/Email') this.value = '';\" /><a\r\n                                    href=\"#\" onclick=\"showWindow('register', '");
	templateBuilder.Append(rooturl.ToString());
	templateBuilder.Append("register.aspx');hideWindow('login');\"\r\n                                    style=\"margin-left: 7px;\" class=\"xg2\">注册</a>\r\n                        </p>\r\n                        <p>\r\n                            <label for=\"ls_password\">\r\n                                密码</label>\r\n                            <input type=\"password\" onfocus=\"lsShowmore();innerVcode();\" tabindex=\"902\" autocomplete=\"off\"\r\n                                id=\"ls_password\" name=\"password\" class=\"txt\" />\r\n                            &nbsp;<input type=\"submit\" style=\"width: 0px; filter: alpha(opacity=0); -moz-opacity: 0;\r\n                                opacity: 0; display: none;\" />\r\n                            <button class=\"pn\" type=\"submit\">\r\n                                <span>登录</span></button>\r\n                        </p>\r\n                    </div>\r\n                </div>\r\n                <div id=\"ls_more\" style=\"position: absolute; display: none;\">\r\n                    <h3 class=\"cl\">\r\n                        <em class=\"y\"><a href=\"###\" class=\"flbc\" title=\"关闭\" onclick=\"closeIsMore();return false;\">\r\n                            关闭</a></em>安全选项</h3>\r\n                    ");
	if (isLoginCode)
	{

	templateBuilder.Append("\r\n                    <div id=\"vcode_header\">\r\n                    </div>\r\n\r\n                    <script type=\"text/javascript\" reload=\"1\">\r\n                        if (typeof vcodeimgid == 'undefined') {\r\n                            var vcodeimgid = 1;\r\n                        }\r\n                        else\r\n                            vcodeimgid++;\r\n                        var secclick = new Array();\r\n                        var seccodefocus = 0;\r\n                        var optionVcode = function (id, type) {\r\n                            id = vcodeimgid;\r\n                            if ($('vcode')) {\r\n                                $('vcode').parentNode.removeChild($('vcode'));\r\n                            }\r\n\r\n                            if (!secclick['vcodetext_header' + id]) {\r\n                                if ($('vcodetext_header' + id) != null)\r\n                                    $('vcodetext_header' + id).value = '';\r\n                                secclick['vcodetext_header' + id] = 1;\r\n                                if (type)\r\n                                    $('vcodetext_header' + id + '_menu').style.top = parseInt($('vcodetext_header' + id + '_menu').style.top) - parseInt($('vcodetext_header' + id + '_menu').style.height) + 'px';\r\n                            }\r\n                            $('vcodetext_header' + id + '_menu').style.display = '';\r\n                            $('vcodetext_header' + id).unselectable = 'off';\r\n                            $('vcodeimg' + id).src = '");
	templateBuilder.Append(rooturl.ToString());
	templateBuilder.Append("tools/VerifyImagePage.aspx?id=");
	templateBuilder.Append(olid.ToString());
	templateBuilder.Append("&time=' + Math.random();\r\n                        }\r\n\r\n                        function innerVcode() {\r\n                            if ($('vcodetext_header1') == null) {\r\n                                $('vcode_header').innerHTML = '<input name=\"vcodetext\" tabindex=\"903\" size=\"20\" onkeyup=\"changevcode(this.form, this.value);\" class=\"txt\" style=\"width:50px;\" id=\"vcodetext_header' + vcodeimgid + '\" value=\"\" autocomplete=\"off\"/>' +\r\n                                                            '<span><a href=\"###\" onclick=\"vcodeimg' + vcodeimgid + '.src=\\'");
	templateBuilder.Append(rooturl.ToString());
	templateBuilder.Append("tools/VerifyImagePage.aspx?id=");
	templateBuilder.Append(olid.ToString());
	templateBuilder.Append("&time=\\' + Math.random();return false;\" style=\"margin-left: 7px;\">看不清</a></span>' + '<p style=\"margin:6px 0\">输入下图中的字符</p>' +\r\n	                                                        '<div  style=\"cursor: pointer;width: 124px; height: 44px;top:256px;z-index:10009;padding:0;\" id=\"vcodetext_header' + vcodeimgid + '_menu\" onmouseout=\"seccodefocus = 0\" onmouseover=\"seccodefocus = 1\"><img src=\"");
	templateBuilder.Append(rooturl.ToString());
	templateBuilder.Append("tools/VerifyImagePage.aspx?time=");
	templateBuilder.Append(Processtime.ToString());
	templateBuilder.Append("\" class=\"cursor\" id=\"vcodeimg' + vcodeimgid + '\" onclick=\"this.src=\\'");
	templateBuilder.Append(rooturl.ToString());
	templateBuilder.Append("tools/VerifyImagePage.aspx?id=");
	templateBuilder.Append(olid.ToString());
	templateBuilder.Append("&time=\\' + Math.random();\"/></div>';\r\n                                optionVcode();\r\n                            }\r\n                        }\r\n\r\n                        function changevcode(form, value) {\r\n                            if (!$('vcode')) {\r\n                                var vcode = document.createElement('input');\r\n                                vcode.id = 'vcode';\r\n                                vcode.name = 'vcode';\r\n                                vcode.type = 'hidden';\r\n                                vcode.value = value;\r\n                                form.appendChild(vcode);\r\n                            } else {\r\n                                $('vcode').value = value;\r\n                            }\r\n                        }\r\n                    </");
	templateBuilder.Append("script>\r\n\r\n                    ");
	}
	else
	{

	templateBuilder.Append("\r\n\r\n                    <script type=\"text/javascript\">\r\n                        function innerVcode() {\r\n                        }\r\n                    </");
	templateBuilder.Append("script>\r\n\r\n                    ");
	}	//end if


	if (config.Secques==1)
	{

	templateBuilder.Append("\r\n                    <div id=\"floatlayout_login\" class=\"pbm\">\r\n                        <select style=\"width: 156px; margin-bottom: 8px;\" id=\"question\" name=\"question\" name=\"question\"\r\n                            onchange=\"displayAnswer();\" tabindex=\"904\">\r\n                            <option id=\"question\" value=\"0\" selected=\"selected\">安全提问(未设置请忽略)</option>\r\n                            <option id=\"question\" value=\"1\">母亲的名字</option>\r\n                            <option id=\"question\" value=\"2\">爷爷的名字</option>\r\n                            <option id=\"question\" value=\"3\">父亲出生的城市</option>\r\n                            <option id=\"question\" value=\"4\">您其中一位老师的名字</option>\r\n                            <option id=\"question\" value=\"5\">您个人计算机的型号</option>\r\n                            <option id=\"question\" value=\"6\">您最喜欢的餐馆名称</option>\r\n                            <option id=\"question\" value=\"7\">驾驶执照的最后四位数字</option>\r\n                        </select>\r\n                        <input type=\"text\" tabindex=\"905\" class=\"txt\" size=\"20\" autocomplete=\"off\" style=\"width: 140px;\r\n                            display: none;\" id=\"answer\" name=\"answer\" />\r\n                    </div>\r\n                    ");
	}	//end if

	templateBuilder.Append("\r\n\r\n                    <script type=\"text/javascript\">\r\n                    function closeIsMore() {\r\n                        $('ls_more').style.display = 'none';\r\n                    }\r\n                    function displayAnswer() {\r\n                        if ($(\"question\").value > 0)\r\n                            $(\"answer\").style.display = \"\";\r\n                        else\r\n                            $(\"answer\").style.display = \"none\";\r\n                    }\r\n                    </");
	templateBuilder.Append("script>\r\n\r\n                    <div class=\"ptm cl\" style=\"border-top: 1px dashed #CDCDCD;\">\r\n                        <a class=\"y xg2\" href=\"#\" onclick=\"hideWindow('register');hideWindow('login');showWindow('getpassword', this.href);\">\r\n                            找回密码</a>\r\n                        <label class=\"z\" for=\"ls_cookietime\">\r\n                            <input type=\"checkbox\" tabindex=\"906\" value=\"2592000\" id=\"ls_cookietime\" name=\"expires\"\r\n                                checked=\"checked\" tabindex=\"906\"><span title=\"下次访问自动登录\">记住我</span></label>\r\n                    </div>\r\n                </div>\r\n                </form>\r\n                ");
	}	//end if


	}
	else
	{

	templateBuilder.Append("\r\n                <div id=\"um\">\r\n                    <div class=\"avt y\">\r\n                        <a alt=\"用户名称\" target=\"_blank\" href=\"");
	templateBuilder.Append(forumpath.ToString());
	templateBuilder.Append("usercp.aspx\">\r\n                            <img src=\"");
	templateBuilder.Append(useravatar.ToString());
	templateBuilder.Append("\" onerror=\"this.onerror=null;this.src='");
	templateBuilder.Append(forumpath.ToString());
	templateBuilder.Append("images/common/noavatar_small.gif';\" /></a></div>\r\n                    <p>\r\n                        <strong><a href=\"");
	templateBuilder.Append(forumpath.ToString());
	templateBuilder.Append("userinfo.aspx?userid=");
	templateBuilder.Append(userid.ToString());
	templateBuilder.Append("\" class=\"vwmy\">");
	templateBuilder.Append(username.ToString());
	templateBuilder.Append("</a></strong><span\r\n                            class=\"xg1\">在线</span><span class=\"pipe\">|</span>\r\n                        ");	string linktitle = "";
	
	string showoverflow = "";
	

	if (oluserinfo.Newpms>0)
	{


	if (oluserinfo.Newpms>=1000)
	{

	 showoverflow = "大于";
	

	}	//end if

	 linktitle = "您有"+showoverflow+oluserinfo.Newpms+"条新短消息";
	

	}
	else
	{

	 linktitle = "您没有新短消息";
	

	}	//end if

	templateBuilder.Append("\r\n                        <a id=\"pm_ntc\" href=\"");
	templateBuilder.Append(forumpath.ToString());
	templateBuilder.Append("usercpinbox.aspx\" title=\"");
	templateBuilder.Append(linktitle.ToString());
	templateBuilder.Append("\">短消息\r\n                            ");
	if (oluserinfo.Newpms>0 && oluserinfo.Newpms<=1000)
	{

	templateBuilder.Append("\r\n                            (");
	templateBuilder.Append(oluserinfo.Newpms.ToString().Trim());
	if (oluserinfo.Newpms>=1000)
	{

	templateBuilder.Append("1000+");
	}	//end if

	templateBuilder.Append(")\r\n                            ");
	}	//end if

	templateBuilder.Append("</a> <span class=\"pipe\">|</span>\r\n                        ");	 showoverflow = "";
	

	if (oluserinfo.Newnotices>0)
	{


	if (oluserinfo.Newnotices>=1000)
	{

	 showoverflow = "大于";
	

	}	//end if

	 linktitle = "您有"+showoverflow+oluserinfo.Newnotices+"条新通知";
	

	}
	else
	{

	 linktitle = "您没有新通知";
	

	}	//end if

	templateBuilder.Append("\r\n                        <a href=\"");
	templateBuilder.Append(forumpath.ToString());
	templateBuilder.Append("usercpnotice.aspx?filter=all\" title=\"");
	templateBuilder.Append(linktitle.ToString());
	templateBuilder.Append("\">通知");
	if (oluserinfo.Newnotices>0)
	{

	templateBuilder.Append("\r\n                            (");
	templateBuilder.Append(oluserinfo.Newnotices.ToString().Trim());
	if (oluserinfo.Newnotices>=1000)
	{

	templateBuilder.Append("+");
	}	//end if

	templateBuilder.Append(")\r\n                            ");
	}	//end if

	templateBuilder.Append("\r\n                        </a><span class=\"pipe\">|</span> <a id=\"usercenter\" class=\"drop\" onmouseover=\"showMenu(this.id);\"\r\n                            href=\"");
	templateBuilder.Append(forumpath.ToString());
	templateBuilder.Append("usercp.aspx\">用户中心</a>\r\n                        ");
	if (config.Regstatus==2||config.Regstatus==3)
	{


	if (userid>0)
	{

	templateBuilder.Append("\r\n                        <span class=\"pipe\">|</span><a href=\"");
	templateBuilder.Append(forumpath.ToString());
	templateBuilder.Append("invite.aspx\">邀请</a>\r\n                        ");
	}	//end if


	}	//end if


	if (useradminid==1)
	{

	templateBuilder.Append("\r\n                        <span class=\"pipe\">|</span><a href=\"");
	templateBuilder.Append(forumpath.ToString());
	templateBuilder.Append("admin/index.aspx\" target=\"_blank\">系统设置</a>\r\n                        ");
	}	//end if

	templateBuilder.Append("\r\n                        <span class=\"pipe\">|</span><a href=\"");
	templateBuilder.Append(forumpath.ToString());
	templateBuilder.Append("logout.aspx?userkey=");
	templateBuilder.Append(userkey.ToString());
	templateBuilder.Append("\">退出</a>\r\n                    </p>\r\n                    ");
	templateBuilder.Append(userinfotips.ToString());
	templateBuilder.Append("\r\n                </div>\r\n                <div id=\"pm_ntc_menu\" class=\"g_up\" style=\"display: none;\">\r\n                    <div class=\"mncr\">\r\n                    </div>\r\n                    <div class=\"crly\">\r\n                        <div style=\"clear: both; font-size: 0;\">\r\n                        </div>\r\n                        <span class=\"y\"><a onclick=\"javascript:$('pm_ntc_menu').style.display='none';closenotice(");
	templateBuilder.Append(oluserinfo.Newpms.ToString().Trim());
	templateBuilder.Append(");\"\r\n                            href=\"javascript:;\">\r\n                            <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/delete.gif\" alt=\"关闭\" /></a></span> <a href=\"");
	templateBuilder.Append(forumpath.ToString());
	templateBuilder.Append("usercpinbox.aspx\">\r\n                                您有");
	if (oluserinfo.Newpms>=1000)
	{

	templateBuilder.Append("大于");
	}	//end if
	templateBuilder.Append(oluserinfo.Newpms.ToString().Trim());
	templateBuilder.Append("条新消息</a>\r\n                    </div>\r\n                </div>\r\n\r\n                <script type=\"text/javascript\">\r\n            setMenuPosition('pm_ntc', 'pm_ntc_menu', '43');\r\n            if(");
	templateBuilder.Append(oluserinfo.Newpms.ToString().Trim());
	templateBuilder.Append(" > 0 && (getcookie(\"shownotice\") != \"0\" || getcookie(\"newpms\") != ");
	templateBuilder.Append(oluserinfo.Newpms.ToString().Trim());
	templateBuilder.Append("))\r\n            {\r\n                $(\"pm_ntc_menu\").style.display='';\r\n            }            \r\n                </");
	templateBuilder.Append("script>\r\n\r\n                ");
	}	//end if

	templateBuilder.Append("\r\n            </div>\r\n            <div id=\"menubar\">\r\n                <a onmouseover=\"showMenu(this.id, false);\" href=\"javascript:void(0);\" id=\"mymenu\">我的中心</a>\r\n                <div class=\"popupmenu_popup headermenu_popup\" id=\"mymenu_menu\" style=\"display: none\">\r\n                    ");
	if (userid!=-1)
	{

	templateBuilder.Append("\r\n                    <ul class=\"sel_my\">\r\n                        <li><a href=\"");
	templateBuilder.Append(forumpath.ToString());
	templateBuilder.Append("mytopics.aspx\">我的主题</a></li>\r\n                        <li><a href=\"");
	templateBuilder.Append(forumpath.ToString());
	templateBuilder.Append("myposts.aspx\">我的帖子</a></li>\r\n                        <li><a href=\"");
	templateBuilder.Append(forumpath.ToString());
	templateBuilder.Append("search.aspx?posterid=current&type=digest&searchsubmit=1\">我的精华</a></li>\r\n                        <li><a href=\"");
	templateBuilder.Append(forumpath.ToString());
	templateBuilder.Append("myattachment.aspx\">我的附件</a></li>\r\n                        <li><a href=\"");
	templateBuilder.Append(forumpath.ToString());
	templateBuilder.Append("usercpsubscribe.aspx\">我的收藏</a></li>\r\n                        ");
	if (config.Enablespace==1)
	{

	templateBuilder.Append("\r\n                        <li class=\"myspace\"><a href=\"");
	templateBuilder.Append(forumpath.ToString());
	templateBuilder.Append("space/\">我的空间</a></li>\r\n                        ");
	}	//end if


	if (config.Enablealbum==1)
	{

	templateBuilder.Append("\r\n                        <li class=\"myalbum\"><a href=\"");
	templateBuilder.Append(forumpath.ToString());
	templateBuilder.Append("showalbumlist.aspx?uid=");
	templateBuilder.Append(userid.ToString());
	templateBuilder.Append("\">我的相册</a></li>\r\n                        ");
	}	//end if

	templateBuilder.Append("\r\n                    </ul>\r\n                    ");
	}
	else
	{

	templateBuilder.Append("\r\n                    <p class=\"reg_tip\">\r\n                        <a href=\"#\" onclick=\"showWindow('register', '");
	templateBuilder.Append(rooturl.ToString());
	templateBuilder.Append("register.aspx');hideWindow('login');\"\r\n                            class=\"xg2\">登录或注册新用户,开通自己的个人中心</a>\r\n                    </p>\r\n                    ");
	}	//end if


	if (config.Allowchangewidth==1&&pagename!="website.aspx")
	{

	templateBuilder.Append("\r\n                    <ul class=\"sel_mb\">\r\n                        <li><a href=\"javascript:;\" onclick=\"widthauto(this,'");
	templateBuilder.Append(cssdir.ToString());
	templateBuilder.Append("')\">\r\n                            ");
	if (isnarrowpage)
	{

	templateBuilder.Append("切换到宽版");
	}
	else
	{

	templateBuilder.Append("切换到窄版");
	}	//end if

	templateBuilder.Append("</a></li>\r\n                    </ul>\r\n                    ");
	}	//end if

	templateBuilder.Append("\r\n                </div>\r\n                <ul id=\"menu\" class=\"cl\">\r\n                    ");
	templateBuilder.Append(mainnavigation.ToString());
	templateBuilder.Append("\r\n                </ul>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    ");
	}
	else
	{


	    Response.Clear(); Response.ContentType = "Text/XML"; Response.Expires = 0; Response.Cache.SetNoStore();
	    
	templateBuilder.Append("\r\n    <?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n    <root>\r\n<![CDATA[ ");
	}	//end if



	templateBuilder.Append("\r\n<div class=\"wrap s_clear pageinfo\">\r\n	<div id=\"nav\">\r\n		<a href=\"");
	templateBuilder.Append(config.Forumurl.ToString().Trim());
	templateBuilder.Append("\" class=\"title\">");
	templateBuilder.Append(config.Forumtitle.ToString().Trim());
	templateBuilder.Append("</a> &raquo;");
	templateBuilder.Append(ShowForumAspxRewrite(forum.Pathlist.Trim(),forumid,forumpageid).ToString().Trim());
	templateBuilder.Append("\r\n		 ");	 aspxrewriteurl = this.ShowTopicAspxRewrite(topicid,0);
	
	templateBuilder.Append("\r\n	     &raquo; <a href=\"");
	templateBuilder.Append(aspxrewriteurl.ToString());
	templateBuilder.Append("\">");
	templateBuilder.Append(topic.Title.ToString().Trim());
	templateBuilder.Append("</a> &raquo; <strong>交易信息</strong>\r\n	</div>\r\n</div>\r\n");
	if (page_err==0)
	{


	if (ispost)
	{


	templateBuilder.Append("<div class=\"wrap s_clear\" id=\"wrap\">\r\n<div class=\"main\">\r\n	<div class=\"msgbox\">\r\n		<h1>");
	templateBuilder.Append(config.Forumtitle.ToString().Trim());
	templateBuilder.Append("　提示信息</h1>\r\n		<hr class=\"solidline\"/>\r\n		<div class=\"msg_inner\">\r\n			<p>");
	templateBuilder.Append(msgbox_text.ToString());
	templateBuilder.Append("</p>\r\n			");
	if (msgbox_url!="")
	{

	templateBuilder.Append("\r\n			<p><a href=\"");
	templateBuilder.Append(msgbox_url.ToString());
	templateBuilder.Append("\">如果浏览器没有转向, 请点击这里.</a></p>\r\n			");
	}	//end if

	templateBuilder.Append("\r\n		</div>\r\n	</div>\r\n</div>\r\n</div>");


	}
	else
	{

	templateBuilder.Append("\r\n    <div class=\"wrap s_clear\" id=\"wrap\">\r\n	<div class=\"main datalist\">\r\n	    ");
	if (buyit==1)
	{

	templateBuilder.Append("\r\n		    <form id=\"form1\" name=\"form1\" method=\"post\" action=\"\">\r\n		    <table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" summary=\"购买主题\" class=\"datatable infotable\">\r\n		    <tbody>\r\n		    <tr>\r\n			    <th>用户名:</th>\r\n			    <td>");
	templateBuilder.Append(username.ToString());
	templateBuilder.Append(" [<a href=\"logout.aspx?userkey=");
	templateBuilder.Append(userkey.ToString());
	templateBuilder.Append("\">退出登录</a>]</td>\r\n		    </tr>\r\n		    <tr>\r\n			    <th>作者:</th>\r\n			    <td>");	 aspxrewriteurl = this.UserInfoAspxRewrite(topic.Posterid);
	
	templateBuilder.Append("\r\n			    <a href=\"");
	templateBuilder.Append(aspxrewriteurl.ToString());
	templateBuilder.Append("\">");
	templateBuilder.Append(topic.Poster.ToString().Trim());
	templateBuilder.Append("</a>\r\n			    </td>\r\n		    </tr>\r\n		    <tr>\r\n			    <th>标题:</th>\r\n			    <td class=\"datatitle\">\r\n			    ");	 aspxrewriteurl = this.ShowTopicAspxRewrite(topicid,0);
	
	templateBuilder.Append("\r\n			    <a href=\"");
	templateBuilder.Append(aspxrewriteurl.ToString());
	templateBuilder.Append("\">");
	templateBuilder.Append(topic.Title.ToString().Trim());
	templateBuilder.Append("</a>\r\n			    </td>\r\n		    </tr>\r\n		    <tr>\r\n			    <th>售价(");
	templateBuilder.Append(userextcreditsinfo.Name.ToString().Trim());
	templateBuilder.Append("):</th>\r\n			    <td>");
	templateBuilder.Append(topicprice.ToString());
	templateBuilder.Append("</td>\r\n		    </tr>\r\n		    <tr>\r\n			    <th>作者所得(");
	templateBuilder.Append(userextcreditsinfo.Name.ToString().Trim());
	templateBuilder.Append("):</th>\r\n			    <td>");
	templateBuilder.Append(netamount.ToString());
	templateBuilder.Append("</td>\r\n		    </tr>\r\n		    <tr>\r\n			    <th>购买后余额(");
	templateBuilder.Append(userextcreditsinfo.Name.ToString().Trim());
	templateBuilder.Append("):</th>\r\n			    <td>");
	templateBuilder.Append(userlastprice.ToString());
	templateBuilder.Append("</td>\r\n		    </tr>\r\n		    <tr>\r\n			    <th>&nbsp;</th>\r\n			    <td>\r\n			    <input type=\"submit\" name=\"paysubmit\" value=\"提交\">\r\n			    </td>\r\n		    </tr>\r\n		    </tbody>\r\n		    </table>\r\n		    </form>\r\n        ");
	}
	else
	{


	if (showpayments==1)
	{


	if (paymentloglist.Rows.Count>0)
	{

	templateBuilder.Append("\r\n		        <table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"  summary=\"购买主题\"  class=\"datatable infotable\">\r\n			        <thead>\r\n			        <tr>\r\n				        <th>");
	templateBuilder.Append(userextcreditsinfo.Name.ToString().Trim());
	templateBuilder.Append("</th>\r\n				        <th>用户名</th>\r\n				        <th>时间</th>\r\n			        </tr>\r\n			        </thead>\r\n			        ");
	int paymentlog__loop__id=0;
	foreach(DataRow paymentlog in paymentloglist.Rows)
	{
		paymentlog__loop__id++;

	templateBuilder.Append("\r\n			        <tbody>\r\n			        <tr>\r\n				        <td><div class=\"ForumBuyTopicLeft\">" + paymentlog["amount"].ToString().Trim() + "</div></td>\r\n				        <th>");	 aspxrewriteurl = this.UserInfoAspxRewrite(paymentlog["uid"].ToString().Trim());
	
	templateBuilder.Append("\r\n                          <a href=\"");
	templateBuilder.Append(aspxrewriteurl.ToString());
	templateBuilder.Append("\" target=\"_blank\">" + paymentlog["username"].ToString().Trim() + "</a></th>\r\n				        <td>" + paymentlog["buydate"].ToString().Trim() + "</td>\r\n			        </tr>\r\n			        </tbody>\r\n			        ");
	}	//end loop

	templateBuilder.Append("\r\n		        </table>\r\n		        ");
	}
	else
	{

	templateBuilder.Append("\r\n		        该主题暂无购买记录\r\n	            ");
	}	//end if


	}	//end if


	if (price>0)
	{

	templateBuilder.Append("\r\n	        <h3>标题:");
	templateBuilder.Append(topic.Title.ToString().Trim());
	templateBuilder.Append("</h3>\r\n	        ");
	templateBuilder.Append(postmessage.ToString());
	templateBuilder.Append("\r\n	        <table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"  class=\"datatable infotable\">\r\n	        <thead>\r\n	        <tr>\r\n		        <th>&nbsp</th>\r\n		        <td>本主题需向作者支付相应积分才能浏览，您可根据作者信誉、出售价格及已购买用户的评价确定购买与否。</td>\r\n	        </tr>\r\n	        </thead>\r\n	        <tbody>\r\n	        <tr>\r\n		        <th >售价(");
	templateBuilder.Append(userextcreditsinfo.Name.ToString().Trim());
	templateBuilder.Append(")</th>\r\n		        <td>");
	templateBuilder.Append(topicprice.ToString());
	templateBuilder.Append("</td>\r\n	        </tr>\r\n	        <tr>\r\n		        <th>积分交易税</th>\r\n		        <td>");
	templateBuilder.Append(creditstax.ToString());
	templateBuilder.Append("%</td>\r\n	        </tr>\r\n	        <tr>\r\n		        <th>作者所得(");
	templateBuilder.Append(userextcreditsinfo.Name.ToString().Trim());
	templateBuilder.Append(")</th>\r\n		        <td>");
	templateBuilder.Append(netamount.ToString());
	templateBuilder.Append("</td>\r\n	        </tr>\r\n	        <tr>\r\n		        <th>已购买人数</th>\r\n		        <td>");
	templateBuilder.Append(buyers.ToString());
	templateBuilder.Append("</td>\r\n	        </tr>\r\n	        <tr>\r\n		        <th>作者最高收入(");
	templateBuilder.Append(userextcreditsinfo.Name.ToString().Trim());
	templateBuilder.Append(")</th>\r\n		        <td>");
	templateBuilder.Append(maxincpertopic.ToString());
	templateBuilder.Append("</td>\r\n	        </tr>\r\n	        <tr>\r\n		        <th>强制免费期限(小时)</th>\r\n		        <td>");
	templateBuilder.Append(maxchargespan.ToString());
	templateBuilder.Append("</td>\r\n	        </tr>\r\n	        <tr>\r\n		        <th>&nbsp;</th>\r\n		        <td>\r\n		        <a href=\"buytopic.aspx?topicid=");
	templateBuilder.Append(topicid.ToString());
	templateBuilder.Append("&showpayments=1\">[查看付款记录]</a><a href=\"buytopic.aspx?topicid=");
	templateBuilder.Append(topicid.ToString());
	templateBuilder.Append("&buyit=1\">[购买主题]</a> <a href=\"#\" onclick=\"history.go(-1)\">[返回上一页]</a>\r\n		        </td>\r\n	        </tr>\r\n	        </tbody>\r\n	        </table>\r\n	        <h3>最后5帖</h3>\r\n	        <table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"  class=\"datatable infotable\">\r\n	        ");
	int lastpost__loop__id=0;
	foreach(DataRow lastpost in lastpostlist.Rows)
	{
		lastpost__loop__id++;

	templateBuilder.Append("\r\n	        <tbody>\r\n	        <tr>\r\n		        <th>");	 aspxrewriteurl = this.UserInfoAspxRewrite(lastpost["posterid"].ToString().Trim());
	
	templateBuilder.Append("\r\n		        <a href=\"");
	templateBuilder.Append(aspxrewriteurl.ToString());
	templateBuilder.Append("\"><strong>" + lastpost["poster"].ToString().Trim() + "</strong></a>&nbsp;&nbsp;" + lastpost["postdatetime"].ToString().Trim() + "\r\n		        </th>\r\n	        </tr>\r\n	        <tr>\r\n		        <td>" + lastpost["message"].ToString().Trim() + "</td>\r\n	        </tr>\r\n	        </tbody>\r\n	        ");
	}	//end loop

	templateBuilder.Append("\r\n	        </table>\r\n	        ");
	}
	else
	{

	templateBuilder.Append("\r\n		        此主题无需购买\r\n	        ");
	}	//end if


	}	//end if


	}	//end if

	templateBuilder.Append("\r\n    </div>\r\n    </div>\r\n");
	}
	else
	{


	if (needlogin)
	{



	if (infloat!=1)
	{

	templateBuilder.Append("\r\n<div class=\"wrap cl\">\r\n	<div class=\"blr\">\r\n	<div class=\"msgbox\" style=\"margin:4px auto;padding:0 !important;margin-left:0;background:none;\">\r\n		<div class=\"msg_inner error_msg\">\r\n			<p>您无权进行当前操作，这可能因以下原因之一造成</p>\r\n			<p><b>");
	templateBuilder.Append(msgbox_text.ToString());
	templateBuilder.Append("</b></p>\r\n			<p>您还没有登录，请填写下面的登录表单后再尝试访问。</p>\r\n		</div>\r\n	</div>\r\n	<hr class=\"solidline\"/>\r\n	<form id=\"formlogin\" name=\"formlogin\" method=\"post\" action=\"");
	templateBuilder.Append(rooturl.ToString());
	templateBuilder.Append("login.aspx\" onsubmit=\"submitLogin(this);\">\r\n	<div class=\"c cl\">\r\n		<div style=\"overflow:hidden;overflow-y:auto\" class=\"lgfm\">\r\n		<input type=\"hidden\" value=\"2592000\" name=\"cookietime\"/>\r\n			<div class=\"sipt lpsw\">\r\n				<label for=\"username\">用户名　：</label>\r\n				<input type=\"text\" id=\"username\" name=\"username\" size=\"25\" maxlength=\"40\" tabindex=\"2\" class=\"txt\" />\r\n			</div>\r\n			<div class=\"sipt lpsw\">\r\n				<label for=\"password\">密　码　：</label>\r\n				<input type=\"password\" name=\"password\" size=\"25\" tabindex=\"3\" class=\"txt\"/>\r\n			</div>\r\n        ");
	if (isLoginCode)
	{

	templateBuilder.Append("\r\n			<div class=\"lpsw\" style=\"position: relative;margin-bottom:10px;\">\r\n				");
	templateBuilder.Append("<div id=\"vcode_temp\"></div>\r\n<script type=\"text/javascript\" reload=\"1\">\r\n	var infloat = ");
	templateBuilder.Append(infloat.ToString());
	templateBuilder.Append(";\r\n	if (typeof vcodeimgid == 'undefined'){\r\n		var vcodeimgid = 1;\r\n	}\r\n	else\r\n	    vcodeimgid++;\r\n\r\n    $('vcode_temp').parentNode.innerHTML = '<input name=\"vcodetext\" ");
	if (infloat==1)
	{

	templateBuilder.Append("tabindex=\"4\"");
	}
	else
	{

	templateBuilder.Append("tabindex=\"7\"");
	}	//end if

	templateBuilder.Append(" size=\"20\" onkeyup=\"changevcode(this.form, this.value);\" class=\"txt\" style=\"width:90px;\" id=\"vcodetext' + vcodeimgid + '\"  onblur=\"if(!seccodefocus) {display(this.id + \\'_menu\\')};\"  onfocus=\"opensecwin('+vcodeimgid+',1)\"   value=\"验证码\" autocomplete=\"off\"/>' +\r\n	                                       '<div class=\"seccodecontent\"  style=\"display:none;cursor: pointer;width: 124px; height: 44px;top:256px;z-index:10009;padding:0;\" id=\"vcodetext' + vcodeimgid + '_menu\" onmouseout=\"seccodefocus = 0\" onmouseover=\"seccodefocus = 1\"><img src=\"");
	templateBuilder.Append(rooturl.ToString());
	templateBuilder.Append("tools/VerifyImagePage.aspx?time=");
	templateBuilder.Append(Processtime.ToString());
	templateBuilder.Append("\" class=\"cursor\" id=\"vcodeimg' + vcodeimgid + '\" onclick=\"this.src=\\'");
	templateBuilder.Append(rooturl.ToString());
	templateBuilder.Append("tools/VerifyImagePage.aspx?id=");
	templateBuilder.Append(olid.ToString());
	templateBuilder.Append("&time=\\' + Math.random();\"/></div>';\r\n	\r\n	function changevcode(form, value){\r\n		if (!$('vcode')){\r\n			var vcode = document.createElement('input');\r\n			vcode.id = 'vcode';\r\n			vcode.name = 'vcode';\r\n			vcode.type = 'hidden';\r\n			vcode.value = value;\r\n			form.appendChild(vcode);\r\n		}else{\r\n			$('vcode').value = value;\r\n		}\r\n	}\r\n</");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\">\r\nvar secclick = new Array();\r\nvar seccodefocus = 0;\r\nfunction opensecwin(id,type) {\r\n	if($('vcode')){\r\n	$('vcode').parentNode.removeChild($('vcode'));}\r\n\r\n	if (!secclick['vcodetext' + id]) {\r\n	    $('vcodetext' + id).value = '';\r\n	    secclick['vcodetext' + id] = 1;\r\n	    if(type)\r\n	        $('vcodetext' + id + '_menu').style.top = parseInt($('vcodetext' + id + '_menu').style.top) - parseInt($('vcodetext' + id + '_menu').style.height) + 'px';\r\n	}\r\n\r\n	$('vcodetext' + id + '_menu').style.position = 'absolute';\r\n	$('vcodetext' + id + '_menu').style.top = (-parseInt($('vcodetext' + id + '_menu').style.height) - 2) + 'px';\r\n	$('vcodetext' + id + '_menu').style.left = '0px';\r\n	$('vcodetext' + id + '_menu').style.display = '';\r\n	$('vcodetext' + id).focus();\r\n	$('vcodetext' + id).unselectable = 'off';\r\n	$('vcodeimg' + id).src = '");
	templateBuilder.Append(rooturl.ToString());
	templateBuilder.Append("tools/VerifyImagePage.aspx?id=");
	templateBuilder.Append(olid.ToString());
	templateBuilder.Append("&time=' + Math.random();\r\n}\r\n</");
	templateBuilder.Append("script>");

	templateBuilder.Append("\r\n			</div>\r\n        ");
	}	//end if


	if (config.Secques==1)
	{

	templateBuilder.Append("\r\n				<div class=\"ftid sltp\" style=\"margin-bottom:10px\">\r\n					<select name=\"question\" id=\"question_login\" change=\"changequestion();\" tabindex=\"5\">\r\n						<option value=\"0\">安全提问（未设置请忽略）</option>\r\n						<option onclick=\"loadselect_liset('question_login', 0, 'question_login','1',this.innerHTML, 1)\" value=\"1\" k_id=\"question_login\">母亲的名字</option>\r\n						<option onclick=\"loadselect_liset('question_login', 0, 'question_login','2',this.innerHTML, 2)\" value=\"2\" k_id=\"question_login\">爷爷的名字</option>\r\n						<option onclick=\"loadselect_liset('question_login', 0, 'question_login','3',this.innerHTML, 3)\" value=\"3\" k_id=\"question_login\">父亲出生的城市</option>\r\n						<option onclick=\"loadselect_liset('question_login', 0, 'question_login','4',this.innerHTML, 4)\" value=\"4\" k_id=\"question_login\">您其中一位老师的名字</option>\r\n						<option onclick=\"loadselect_liset('question_login', 0, 'question_login','5',this.innerHTML, 5)\" value=\"5\" k_id=\"question_login\">您个人计算机的型号</option>\r\n						<option onclick=\"loadselect_liset('question_login', 0, 'question_login','6',this.innerHTML, 6)\" value=\"6\" k_id=\"question_login\">您最喜欢的餐馆名称</option>\r\n						<option onclick=\"loadselect_liset('question_login', 0, 'question_login','7',this.innerHTML, 7)\" value=\"7\" k_id=\"question_login\">驾驶执照的最后四位数字</option>\r\n					</select>\r\n					<script type=\"text/javascript\">simulateSelect('question_login', '214');</");
	templateBuilder.Append("script>\r\n					<script type=\"text/javascript\">\r\n					    window.onload = function(){setselect(");
	templateBuilder.Append(question.ToString());
	templateBuilder.Append(");}\r\n				        function changequestion() {\r\n				            if ($('question_login').getAttribute(\"selecti\") != \"0\") {\r\n				                $('answer_login').style.display = '';\r\n						        $('answer_login').focus();\r\n				            }\r\n				            else {\r\n				                $('answer_login').style.display = 'none';\r\n				            }\r\n				        }\r\n				        function setselect(value) {\r\n				            try {\r\n                                var questionarray = new Array('安全提问','母亲的名字','爷爷的名字','父亲出生的城市','您其中一位老师的名字','您个人计算机的型号','您最喜欢的餐馆名称','驾驶执照的最后四位数字');\r\n                                $('question_login').setAttribute(\"selecti\",value);\r\n                                $('question_login').options[0].value = value;\r\n                                $('question_ctrl').innerHTML = questionarray[value];\r\n                                changequestion();\r\n				            }\r\n				            catch (e) {\r\n				            }\r\n				        }\r\n\r\n					</");
	templateBuilder.Append("script>\r\n				</div>\r\n				<div class=\"sltp\" style=\"clear:both;\"><input type=\"text\" tabindex=\"6\" class=\"txt\" size=\"36\" autocomplete=\"off\" style=\"display: none;\" id=\"answer_login\" name=\"answer\"/></div>\r\n			");
	}	//end if

	templateBuilder.Append("\r\n			<div class=\"sltp\"  style=\"display:none\">\r\n				<label for=\"templateid\">界面风格</label>\r\n				<select name=\"templateid\" tabindex=\"7\">\r\n				<option value=\"0\">- 使用默认 -</option>\r\n					");
	templateBuilder.Append(templatelistboxoptions.ToString());
	templateBuilder.Append("\r\n				</select>\r\n			</div>\r\n		</div>\r\n		<div class=\"lgf\">\r\n			<h4>没有帐号？\r\n				");
	if (infloat==1)
	{

	templateBuilder.Append("\r\n				<a href=\"#\"  onclick=\"hideWindow('login');showWindow('register', this.href);\" class=\"xg2\">立即注册</a>\r\n				");
	}
	else
	{

	templateBuilder.Append("\r\n				<a href=\"http://www.feipiao.cn/index.php?act=signup\" tabindex=\"-1\" accesskey=\"r\" title=\"立即注册 (ALT + R)\" class=\"xg2\">立即注册</a>\r\n				");
	}	//end if

	templateBuilder.Append("\r\n			</h4>\r\n			<p>\r\n				");
	if (infloat==1)
	{

	templateBuilder.Append("\r\n				<a href=\"#\" onclick=\"hideWindow('login');showWindow('getpassword', this.href);\" accesskey=\"g\" title=\"忘记密码 (ALT + G)\" class=\"xg2\">找回密码</a>\r\n				");
	}
	else
	{

	templateBuilder.Append("\r\n				<a href=\"http://www.feipiao.cn/index.php?act=login\" accesskey=\"g\" title=\"找回密码\" class=\"xg2\">找回密码</a>\r\n				");
	}	//end if

	templateBuilder.Append("\r\n			</p>\r\n		</div>\r\n	</div>\r\n	<p class=\"fsb pns cl\">\r\n		<input type=\"submit\" style=\"width:0;filter:alpha(opacity=0);-moz-opacity:0;opacity:0;\"/>\r\n		<button name=\"login\" type=\"submit\" id=\"login\" tabindex=\"8\" ");
	if (infloat!=1)
	{

	templateBuilder.Append("onclick=\"javascript:window.location.replace('?agree=yes')\"");
	}	//end if

	templateBuilder.Append(" class=\"pn\"><span>登录</span></button>\r\n		<input type=\"checkbox\" value=\"43200\" tabindex=\"9\" id=\"expires\" name=\"expires\" checked/>\r\n		<label for=\"expires\"><span title=\"下次访问自动登录\">记住我</span></label>\r\n	</p>\r\n	<script type=\"text/javascript\">\r\n		document.getElementById(\"username\").focus();\r\n	</");
	templateBuilder.Append("script>\r\n	</form>\r\n</div>\r\n</div>\r\n");
	}
	else
	{

	templateBuilder.Append("\r\n<div class=\"main\">\r\n	<div class=\"msgbox\">\r\n		<h1>");
	templateBuilder.Append(config.Forumtitle.ToString().Trim());
	templateBuilder.Append(" 提示信息</h1>\r\n		<hr class=\"solidline\"/>\r\n		<div class=\"msg_inner error_msg\">\r\n			<p>您无权进行当前操作，这可能因以下原因之一造成</p>\r\n			<p><b>");
	templateBuilder.Append(msgbox_text.ToString());
	templateBuilder.Append("</b></p>\r\n			<p>您还没有登录，请填写下面的登录表单后再尝试访问。</p>\r\n		</div>\r\n	</div>\r\n</div>\r\n<script type=\"text/javascript\" reload=\"1\">\r\nsetTimeout(\"floatwin('close_newthread');floatwin('close_reply');floatwin('close_edit');floatwin('open_login', '");
	templateBuilder.Append(forumurl.ToString());
	templateBuilder.Append("login.aspx', 600, 410)\",1000);\r\n</");
	templateBuilder.Append("script>\r\n");
	}	//end if

	templateBuilder.Append("	\r\n<script type=\"text/javascript\">\r\n        ");
	if (infloat!=1)
	{

	templateBuilder.Append("\r\n		document.getElementById(\"username\").focus();\r\n        ");
	}	//end if

	templateBuilder.Append("\r\n		function submitLogin(loginForm)\r\n		{\r\n//		    loginForm.action = '");
	templateBuilder.Append(rooturl.ToString());
	templateBuilder.Append("login.aspx?loginsubmit=true&reurl=' + escape(window.location);\r\n            loginForm.action = '");
	templateBuilder.Append(rooturl.ToString());
	templateBuilder.Append("login.aspx?reurl=' + escape(window.location);\r\n            \r\n			loginForm.submit();\r\n		}\r\n</");
	templateBuilder.Append("script>");


	}
	else
	{


	templateBuilder.Append("<div class=\"wrap cl\">\r\n<div class=\"main\">\r\n	<div class=\"msgbox\">\r\n		<h1>出现了");
	templateBuilder.Append(page_err.ToString());
	templateBuilder.Append("个错误</h1>\r\n		<hr class=\"solidline\"/>\r\n		<div class=\"msg_inner error_msg\">\r\n			<p>");
	templateBuilder.Append(msgbox_text.ToString());
	templateBuilder.Append("</p>\r\n			<p class=\"errorback\">\r\n				<script type=\"text/javascript\">\r\n					if(");
	templateBuilder.Append(msgbox_showbacklink.ToString());
	templateBuilder.Append(")\r\n					{\r\n						document.write(\"<a href=\\\"");
	templateBuilder.Append(msgbox_backlink.ToString());
	templateBuilder.Append("\\\">返回上一步</a> &nbsp; &nbsp;|&nbsp; &nbsp  \");\r\n					}\r\n				</");
	templateBuilder.Append("script>\r\n				<a href=\"forumindex.aspx\">论坛首页</a>\r\n				");
	if (usergroupid==7)
	{

	templateBuilder.Append("\r\n				 &nbsp; &nbsp;|&nbsp; &nbsp; <a href=\"login.aspx\">登录</a>&nbsp; &nbsp;|&nbsp; &nbsp; <a href=\"http://www.feipiao.cn/index.php?act=signup\">注册</a>\r\n				");
	}	//end if

	templateBuilder.Append("\r\n			</p>\r\n		</div>\r\n	</div>\r\n</div>\r\n</div>");


	}	//end if


	}	//end if



	if (infloat!=1)
	{


	if (pagename=="website.aspx")
	{

	templateBuilder.Append("    \r\n       <div id=\"websitebottomad\"></div>\r\n");
	}
	else if (footerad!="")
	{

	templateBuilder.Append(" \r\n     <div id=\"ad_footerbanner\">");
	templateBuilder.Append(footerad.ToString());
	templateBuilder.Append("</div>   \r\n");
	}	//end if

	templateBuilder.Append("\r\n<div id=\"footer\">\r\n	<div class=\"wrap\"  id=\"wp\">\r\n		<div id=\"footlinks\">\r\n			<p><a href=\"");
	templateBuilder.Append(config.Weburl.ToString().Trim());
	templateBuilder.Append("\" target=\"_blank\">");
	templateBuilder.Append(config.Webtitle.ToString().Trim());
	templateBuilder.Append("</a> - ");
	templateBuilder.Append(config.Linktext.ToString().Trim());
	templateBuilder.Append(" - <a target=\"_blank\" href=\"");
	templateBuilder.Append(forumurl.ToString());
	templateBuilder.Append("stats.aspx\">统计</a> - ");
	if (config.Sitemapstatus==1)
	{

	templateBuilder.Append("&nbsp;<a href=\"");
	templateBuilder.Append(forumurl.ToString());
	templateBuilder.Append("tools/sitemap.aspx\" target=\"_blank\" title=\"百度论坛收录协议\">Sitemap</a>");
	}	//end if

	templateBuilder.Append("\r\n			");
	templateBuilder.Append(config.Statcode.ToString().Trim());
	templateBuilder.Append(config.Icp.ToString().Trim());
	templateBuilder.Append("\r\n			</p>\r\n			<div>\r\n				<a href=\"http://www.comsenz.com/\" target=\"_blank\">Comsenz Technology Ltd</a>\r\n				- <a href=\"");
	templateBuilder.Append(forumurl.ToString());
	templateBuilder.Append("archiver/index.aspx\" target=\"_blank\">简洁版本</a>\r\n			");
	if (config.Stylejump==1)
	{


	if (userid!=-1 || config.Guestcachepagetimeout<=0)
	{

	templateBuilder.Append("\r\n				- <span id=\"styleswitcher\" class=\"drop\" onmouseover=\"showMenu({'ctrlid':this.id, 'pos':'21'})\" onclick=\"window.location.href='");
	templateBuilder.Append(forumurl.ToString());
	templateBuilder.Append("showtemplate.aspx'\">界面风格</span>\r\n				");
	}	//end if


	}	//end if

	templateBuilder.Append("\r\n			</div>\r\n		</div>\r\n		<a title=\"Powered by Discuz!NT\" target=\"_blank\" href=\"http://nt.discuz.net\"><img border=\"0\" alt=\"Discuz!NT\" src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/discuznt_logo.gif\"/></a>\r\n		<p id=\"copyright\">\r\n			Powered by <strong><a href=\"http://nt.discuz.net\" target=\"_blank\" title=\"Discuz!NT\">Discuz!NT</a></strong> <em class=\"f_bold\">3.6.601</em>\r\n			");
	if (config.Licensed==1)
	{

	templateBuilder.Append("\r\n				(<a href=\"\" onclick=\"this.href='http://nt.discuz.net/certificate/?host='+location.href.substring(0, location.href.lastIndexOf('/'))\" target=\"_blank\">Licensed</a>)\r\n			");
	}	//end if

	templateBuilder.Append("\r\n				");
	templateBuilder.Append(config.Forumcopyright.ToString().Trim());
	templateBuilder.Append("\r\n		</p>\r\n		<p id=\"debuginfo\" class=\"grayfont\">\r\n		");
	if (config.Debug!=0)
	{

	templateBuilder.Append("\r\n			Processed in ");
	templateBuilder.Append(this.Processtime.ToString().Trim());
	templateBuilder.Append(" second(s)\r\n			");
	if (isguestcachepage==1)
	{

	templateBuilder.Append("\r\n				(Cached).\r\n			");
	}
	else if (querycount>1)
	{

	templateBuilder.Append("\r\n				 , ");
	templateBuilder.Append(querycount.ToString());
	templateBuilder.Append(" queries.\r\n			");
	}
	else
	{

	templateBuilder.Append("\r\n				 , ");
	templateBuilder.Append(querycount.ToString());
	templateBuilder.Append(" query.\r\n			");
	}	//end if


	}	//end if

	templateBuilder.Append("\r\n		</p>\r\n	</div>\r\n</div>\r\n<a id=\"scrolltop\" href=\"javascript:;\" style=\"display:none;\" class=\"scrolltop\" onclick=\"setScrollToTop(this.id);\">TOP</a>\r\n<ul id=\"usercenter_menu\" class=\"p_pop\" style=\"display:none;\">\r\n    <li><a href=\"");
	templateBuilder.Append(forumpath.ToString());
	templateBuilder.Append("usercpprofile.aspx?action=avatar\">设置头像</a></li>\r\n    <li><a href=\"");
	templateBuilder.Append(forumpath.ToString());
	templateBuilder.Append("usercpprofile.aspx\">个人资料</a></li>\r\n    <li><a href=\"");
	templateBuilder.Append(forumpath.ToString());
	templateBuilder.Append("usercpnewpassword.aspx\">更改密码</a></li>\r\n    <li><a href=\"");
	templateBuilder.Append(forumpath.ToString());
	templateBuilder.Append("usercp.aspx\">用户组</a></li>\r\n    <li><a href=\"");
	templateBuilder.Append(forumpath.ToString());
	templateBuilder.Append("usercpsubscribe.aspx\">收藏夹</a></li>\r\n    <li><a href=\"");
	templateBuilder.Append(forumpath.ToString());
	templateBuilder.Append("usercpcreditspay.aspx\">积分</a></li>\r\n</ul>\r\n\r\n");
	int prentid__loop__id=0;
	foreach(string prentid in mainnavigationhassub)
	{
		prentid__loop__id++;

	templateBuilder.Append("\r\n<ul class=\"p_pop\" id=\"menu_");
	templateBuilder.Append(prentid.ToString());
	templateBuilder.Append("_menu\" style=\"display: none\">\r\n");
	int subnav__loop__id=0;
	foreach(DataRow subnav in subnavigation.Rows)
	{
		subnav__loop__id++;

	bool isoutput = false;
	

	if (subnav["parentid"].ToString().Trim()==prentid)
	{


	if (subnav["level"].ToString().Trim()=="0")
	{

	 isoutput = true;
	

	}
	else
	{


	if (subnav["level"].ToString().Trim()=="1" && userid!=-1)
	{

	 isoutput = true;
	

	}
	else
	{

	bool leveluseradmindi = true;
	
	 leveluseradmindi = (useradminid==3 || useradminid==1 || useradminid==2);
	

	if (subnav["level"].ToString().Trim()=="2" &&  leveluseradmindi)
	{

	 isoutput = true;
	

	}	//end if


	if (subnav["level"].ToString().Trim()=="3" && useradminid==1)
	{

	 isoutput = true;
	

	}	//end if


	}	//end if


	}	//end if


	}	//end if


	if (isoutput)
	{


	if (subnav["id"].ToString().Trim()=="11" || subnav["id"].ToString().Trim()=="12")
	{


	if (config.Statstatus==1)
	{

	templateBuilder.Append("\r\n	" + subnav["nav"].ToString().Trim() + "\r\n        ");	continue;


	}
	else
	{

	continue;


	}	//end if


	}	//end if


	if (subnav["id"].ToString().Trim()=="18")
	{


	if (config.Oltimespan>0)
	{

	templateBuilder.Append("\r\n    " + subnav["nav"].ToString().Trim() + "\r\n	");	continue;


	}
	else
	{

	continue;


	}	//end if


	}	//end if


	if (subnav["id"].ToString().Trim()=="24")
	{


	if (config.Enablespace==1)
	{

	templateBuilder.Append("\r\n    " + subnav["nav"].ToString().Trim() + "\r\n 	");	continue;


	}
	else
	{

	continue;


	}	//end if


	}	//end if


	if (subnav["id"].ToString().Trim()=="25")
	{


	if (config.Enablealbum==1)
	{

	templateBuilder.Append("\r\n    " + subnav["nav"].ToString().Trim() + "\r\n 	");	continue;


	}
	else
	{

	continue;


	}	//end if


	}	//end if


	if (subnav["id"].ToString().Trim()=="26")
	{


	if (config.Enablemall>=1)
	{

	templateBuilder.Append("\r\n    " + subnav["nav"].ToString().Trim() + "\r\n   	");	continue;


	}
	else
	{

	continue;


	}	//end if


	}	//end if

	templateBuilder.Append("\r\n    " + subnav["nav"].ToString().Trim() + "\r\n");
	}	//end if


	}	//end loop

	templateBuilder.Append("\r\n</ul>\r\n");
	}	//end loop


	if (config.Stylejump==1)
	{


	if (userid!=-1 || config.Guestcachepagetimeout<=0)
	{

	templateBuilder.Append("\r\n	<ul id=\"styleswitcher_menu\" class=\"popupmenu_popup s_clear\" style=\"display: none;\">\r\n	");
	templateBuilder.Append(templatelistboxoptions.ToString());
	templateBuilder.Append("\r\n	</ul>\r\n	");
	}	//end if


	}	//end if




	templateBuilder.Append("</body>\r\n</html>\r\n");
	}
	else
	{

	templateBuilder.Append("\r\n]]></root>\r\n");
	}	//end if




	Response.Write(templateBuilder.ToString());
}
</script>
