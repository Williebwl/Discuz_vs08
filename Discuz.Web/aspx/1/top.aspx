<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Discuz.Web.top" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Discuz.Common" %>
<%@ Import namespace="Discuz.Forum" %>
<%@ Import namespace="Discuz.Entity" %>
<%@ Import namespace="Discuz.Config" %>

<script runat="server">
override protected void OnInit(EventArgs e)
{

	/* 
		This page was created by Discuz!NT Template Engine at 2013/04/16 17:01:38.
		本页面代码由Discuz!NT模板引擎生成于 2013/04/16 17:01:38. 
	*/

	base.OnInit(e);

	templateBuilder.Capacity = 220000;
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
	Response.Write(templateBuilder.ToString());
}
</script>
