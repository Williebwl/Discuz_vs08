<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Discuz.Web.taohua_xianzi" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Discuz.Common" %>
<%@ Import namespace="Discuz.Forum" %>
<%@ Import namespace="Discuz.Entity" %>
<%@ Import namespace="Discuz.Config" %>

<script runat="server">
override protected void OnInit(EventArgs e)
{

	/* 
		This page was created by Discuz!NT Template Engine at 2013/04/16 17:01:37.
		本页面代码由Discuz!NT模板引擎生成于 2013/04/16 17:01:37. 
	*/

	base.OnInit(e);

	templateBuilder.Capacity = 220000;
	templateBuilder.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n    <title>");
	templateBuilder.Append(pagetitle.ToString());
	templateBuilder.Append(" - ");
	templateBuilder.Append(config.Forumtitle.ToString().Trim());
	templateBuilder.Append(" ");
	templateBuilder.Append(config.Seotitle.ToString().Trim());
	templateBuilder.Append(" </title>\r\n    <link href=\"");
	templateBuilder.Append(cssdir.ToString());
	templateBuilder.Append("/taohua.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n    <link href=\"");
	templateBuilder.Append(cssdir.ToString());
	templateBuilder.Append("/top-nav.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n    <link href=\"");
	templateBuilder.Append(cssdir.ToString());
	templateBuilder.Append("/fot.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n    <style type=\"text/css\">\r\n        .previewShowWindow{position:absolute;border:1px solid #dadade;background:#95959d;padding:5px;display:none;color:#fff;text-align:center;z-index:999;}\r\n    </style>\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append(config.Jqueryurl.ToString().Trim());
	templateBuilder.Append("\"></");
	templateBuilder.Append("script>\r\n\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append(jsdir.ToString());
	templateBuilder.Append("/jBox/jquery.jBox-2.3.min.js\"></");
	templateBuilder.Append("script>\r\n\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append(jsdir.ToString());
	templateBuilder.Append("/jBox/i18n/jquery.jBox-zh-CN.js\"></");
	templateBuilder.Append("script>\r\n\r\n    <link type=\"text/css\" rel=\"stylesheet\" href=\"");
	templateBuilder.Append(jsdir.ToString());
	templateBuilder.Append("/jBox/Skins/Red/jbox.css\" />\r\n    \r\n    \r\n    <script src=\"");
	templateBuilder.Append(jsdir.ToString());
	templateBuilder.Append("/jquery.lazyload.js?t=20130315.js\" type=\"text/javascript\"></");
	templateBuilder.Append("script>\r\n    <script src=\"");
	templateBuilder.Append(jsdir.ToString());
	templateBuilder.Append("/preview.js?t=20130407.js\" type=\"text/javascript\"></");
	templateBuilder.Append("script>\r\n\r\n    <script type=\"text/javascript\">\r\n//     $(document).ready(\r\n//          function($){\r\n//          $(\"img\").lazyload({\r\n//            placeholder : \"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/grey.jpg\", //加载图片前的占位图片\r\n//                 effect : \"fadeIn\", //加载图片使用的效果(淡入)\r\n//            container: $(\".photos\")\r\n//           });\r\n//          });\r\n      \r\n      function SearchFocus(){\r\n          var topsearch=$('#txt_topsearch');\r\n          if(topsearch.val()=='景区或酒店名称')\r\n          {\r\n            topsearch.val(\"\")\r\n          }\r\n        }\r\n\r\n        function SearchBlur(){\r\n          var topsearch=$('#txt_topsearch');\r\n          if(topsearch.val()==''){\r\n            topsearch.val(\"景区或酒店名称\");\r\n          }\r\n        }\r\n        \r\n        function xuanshouBlur(){\r\n           var aid=$('#txt_aid');\r\n          if(aid.val()=='')\r\n           {\r\n             aid.val(\"输入选手号/姓名\");\r\n             aid.css(\"color\",\"#D0D0D0\");\r\n           }\r\n        }\r\n        function xuanshuFocus(){\r\n          var aid=$('#txt_aid'); \r\n          if(aid.val()=='输入选手号/姓名')\r\n          {\r\n             aid.val('');\r\n             aid.css(\"color\",\"#000\");\r\n          }\r\n        }\r\n    </");
	templateBuilder.Append("script>\r\n\r\n    <script src=\"");
	templateBuilder.Append(jsdir.ToString());
	templateBuilder.Append("/taohua_xianzi.js?t=20130315.js\" type=\"text/javascript\"></");
	templateBuilder.Append("script>\r\n\r\n</head>\r\n<body>\r\n    ");
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

	templateBuilder.Append("\r\n    <div class=\"purple\">\r\n        <div class=\"backtop\">\r\n            <div id=\"xianzi_box\">\r\n                <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/top_02.jpg\" border=\"0\" />\r\n            </div>\r\n        </div>\r\n        <div class=\"backtop02\">\r\n            <div id=\"xianzi_box\">\r\n                <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/top_04.jpg\" />\r\n                <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/top_05.jpg\" />\r\n            </div>\r\n        </div>\r\n        <div class=\"backtop03\">\r\n            <div id=\"xianzi_box\">\r\n                <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/top_06.jpg\" width=\"989\" height=\"306\" border=\"0\" usemap=\"#Map\" />\r\n                <map name=\"Map\" id=\"Map\">\r\n                    <area shape=\"rect\" coords=\"81,226,219,251\" href=\"taohua_5000.aspx\" target=\"_blank\" />\r\n                    <area shape=\"rect\" coords=\"434,258,570,286\" href=\"userlottery.aspx\" target=\"_blank\" />\r\n                    <area shape=\"rect\" coords=\"408,212,409,213\" href=\"#\" target=\"_blank\" />\r\n                </map>\r\n                <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/top_07.jpg\" />\r\n            </div>\r\n        </div>\r\n        <div class=\"backtop04\">\r\n            <div id=\"xianzi_box\">\r\n                <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/top_08.jpg\" />\r\n            </div>\r\n        </div>\r\n        <div id=\"xianzi_box\">\r\n            <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/top_09.jpg\" />\r\n            <div class=\"The_rules\">\r\n                <div class=\"zj_left\">\r\n                    <h2 class=\"daoyu\">\r\n                        导语:</h2>\r\n                    <ul class=\"step\">\r\n                        <li>\r\n                            <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/stpe1.gif\" width=\"161\" height=\"109\" /></li>\r\n                        <li>\r\n                            <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/stpe2.gif\" width=\"161\" height=\"109\" /></li>\r\n                        <li>\r\n                            <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/stpe3.gif\" width=\"161\" height=\"109\" /></li>\r\n                        <li>\r\n                            <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/stpe4.gif\" width=\"151\" height=\"109\" /></li>\r\n                        <div class=\"clear\">\r\n                        </div>\r\n                    </ul>\r\n                    <div class=\"jb_xian\">\r\n                        <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/stpe_xian.gif\" /></div>\r\n                    <dl class=\"instructions\">\r\n                        <dt>\r\n                            <h2>\r\n                                活动详细:</h2>\r\n                            活动时间：报名时间 2013-3-25 至 2013-4-15 投票时间 2013-4-16 至 2013-5-5 复选时间 5月中旬</dt>\r\n                        <dd style=\"font-weight: bold; font-size: 14px;\">\r\n                            报名条件：</dd>\r\n                        <dd>\r\n                            1.需提供本人正面与桃花的合影照片；</dd>\r\n                        <dd>\r\n                            2.照片为素颜照或淡妆照，浓妆不予入选；</dd>\r\n                        <dd>\r\n                            3.照片经图形软件过度处理失真不予入选；</dd>\r\n                        <dd>\r\n                            4.报名者须女性，年龄在17岁至35岁之间。</dd>\r\n                    </dl>\r\n                </div>\r\n                <div class=\"sign_up\">\r\n                    <ul class=\"sign_bot\">\r\n                        <li><span>一等奖 1名</span></li>\r\n                        <li>迪拜七星酒店奢华之旅7日游 <a href=\"showtopic-135.aspx\" target=\"_blank\">详细</a></li>\r\n                        <li><span>二等奖 2名</span></li>\r\n                        <li>三亚荔苑雨林别墅浪漫之旅3日游 <a href=\"showtopic-136.aspx\" target=\"_blank\">详细</a></li>\r\n                        <li><span>三等奖 3名</span></li>\r\n                        <li>千岛湖希尔顿心灵之旅3日游 <a href=\"showtopic-137.aspx\" target=\"_blank\">详细</a></li>\r\n                        <div class=\"clear\">\r\n                        </div>\r\n                    </ul>\r\n                    <div class=\"canjia_aniu\">\r\n                        <a href=\"showforum-36.aspx\" target=\"_blank\">\r\n                            <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/cjanniu.gif\" border=\"0\" /></a></div>\r\n                </div>\r\n                <div class=\"clear\">\r\n                </div>\r\n                <div class=\"pingxuan\">\r\n                    <h2>\r\n                        评选规则：</h2>\r\n                    评选在报名结束后的规定时间内接受会员的投票，每位网民只能投票一次重复无效，各类排行榜以会员得到的有效选票总数由高到低排列，实时动态显示。</div>\r\n            </div>\r\n            <div class=\"contestants\">\r\n                <form action=\"\" method=\"get\" id=\"formsearch\" name=\"formsearch\">\r\n                <ul  class=\"contestants_top\">\r\n                    <li>\r\n                        <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/cansai.gif\" width=\"311\" height=\"139\" align=\"left\" /></li>\r\n                    <li class=\"search\">\r\n                        <input name=\"txt_aid\" id=\"txt_aid\" type=\"text\" style=\"color: rgb(0, 0, 0);\" onblur=\"xuanshouBlur();\" onfocus=\"xuanshuFocus();\" value=\"输入选手号/姓名\" />\r\n                        <input id=\"page\" type=\"hidden\" value=\"");
	templateBuilder.Append(pageid.ToString());
	templateBuilder.Append("\" name=\"page\" />\r\n                        <input id=\"orderby\" type=\"hidden\" value=\"");
	templateBuilder.Append(orderby.ToString());
	templateBuilder.Append("\" name=\"orderby\" />\r\n                        <input id=\"ordertype\" type=\"hidden\" value=\"");
	templateBuilder.Append(ordertype.ToString());
	templateBuilder.Append("\" name=\"ordertype\" />\r\n                        <a href=\"javascript:void(0);\" onclick=\"document.formsearch.submit();\">\r\n                            <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/search02.gif\" id=\"img_search\" width=\"37\" height=\"32\" align=\"absmiddle\" /></a>\r\n                    </li>\r\n                    <li style=\"margin-top: 99px;\"><a href=\"javascript:void(0);\" onclick=\"document.formsearch.submit();\">\r\n                        <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/search03.gif\" id=\"img_orderby\" /></a></li>\r\n                    <li style=\"margin-top: 99px; float: right\">\r\n                        <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/cansai02.gif\" width=\"214\" height=\"40\" align=\"right\" /></li>\r\n                    <div class=\"clear\">\r\n                    </div>\r\n                </ul>\r\n\r\n                <script type=\"text/javascript\">\r\n					    var ordertype=$('#ordertype');\r\n                           if(ordertype.val()==''){\r\n                              $('#img_orderby').attr('src','");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/search03.gif');\r\n                           }else\r\n                           {\r\n                              if(ordertype.val()=='desc')//从高到低\r\n                              { \r\n                                ordertype.val('asc');\r\n                                $('#img_orderby').attr('src','");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/search_33.gif');\r\n                              }else if(ordertype.val()=='asc')//从低到高\r\n                              {\r\n                                ordertype.val('desc');\r\n                                $('#img_orderby').attr('src','");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/search03.gif');\r\n                              }\r\n                           }\r\n                </");
	templateBuilder.Append("script>\r\n\r\n                </form>\r\n                <div class=\"roed\">\r\n                    <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/cansai03.gif\" width=\"174\" height=\"29\" align=\"right\" /></div>\r\n                <ul class=\"photos\">\r\n                    ");
	int vote__loop__id=0;
	foreach(DataRow vote in vote_list.Rows)
	{
		vote__loop__id++;

	templateBuilder.Append("\r\n                    <li>\r\n                        <dl>\r\n                            <dt>\r\n                            <a href=\"javascript:void(0);\" onclick=\"Votepic(" + vote["aid"].ToString().Trim() + "," + vote["uid"].ToString().Trim() + ");\" path=\"upload/" + vote["filename"].ToString().Trim() + "\" class=\"preview\">\r\n                                <img src=\"upload/" + vote["filename"].ToString().Trim() + "\" width=\"200\" height=\"247\" border=\"0\" /></a>\r\n                                </dt>\r\n                            ");	string voteinfo = Utils.GetSubString(vote["aid"].ToString().Trim()+"号 "+ vote["title"].ToString().Trim(),18,"...");
	
	templateBuilder.Append("\r\n                            <dd title=\"" + vote["aid"].ToString().Trim() + "号 " + vote["title"].ToString().Trim() + "\">\r\n                                ");
	templateBuilder.Append(voteinfo.ToString());
	templateBuilder.Append("</dd>\r\n                            <dd>\r\n                            </dd>\r\n                            <dd>\r\n                                <span>已获<label id=\"lblticketnum" + vote["aid"].ToString().Trim() + "\">" + vote["ticketnum"].ToString().Trim() + "</label>票</span></dd>\r\n                            <dd>\r\n                                <a href=\"javascript:void(0);\" onclick=\"CheckVote(" + vote["aid"].ToString().Trim() + ",'" + vote["title"].ToString().Trim() + "'," + vote["uid"].ToString().Trim() + ");\">\r\n                                    <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/toupiao.gif\" align=\"texttop\" border=\"0\" /></a></dd>\r\n                            <div class=\"clear\">\r\n                            </div>\r\n                        </dl>\r\n                    </li>\r\n                    ");
	}	//end loop

	templateBuilder.Append("\r\n                    <div class=\"clear\">\r\n                    </div>\r\n                </ul>\r\n                <!--<ul class=\"list_page\">\r\n                    <li><a href=\"#\" class=\"one\">1</a></li>\r\n                    <li><a href=\"#\">2</a></li>\r\n                    <li><a href=\"#\">3</a></li>\r\n                    <li><a href=\"#\">...</a></li>\r\n                    <li><a href=\"#\">5</a></li>\r\n                </ul>-->\r\n                <div class=\"wrap cl\">\r\n                    <div class=\"main datalist\">\r\n                        <div class=\"pages_btns cl\">\r\n                            <div class=\"pages\">\r\n                                <kbd>共");
	templateBuilder.Append(totalvote.ToString());
	templateBuilder.Append("位选手</kbd>");
	templateBuilder.Append(pagenumbers.ToString());
	templateBuilder.Append("<kbd>共");
	templateBuilder.Append(pagecount.ToString());
	templateBuilder.Append("页</kbd>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n                <div class=\"clear\">\r\n                </div>\r\n            </div>\r\n            <dl class=\"Matters\">\r\n                <dt>注意事项</dt>\r\n                <dd>\r\n                    1.本次活动中的获奖信息，活动主办方将以邮件和电话联络2种方式通知获奖网友。</dd>\r\n                <dd>\r\n                    2.本次活动中获奖的网友请在收到获奖信息后，尽快回复主办方（飞票网）的获奖通知信。如在获奖信息公布10天内仍未回复确认，则视为放弃。</dd>\r\n                <dd>\r\n                    3.本次活动严谨作弊，一经发现，即取消相关参与者的获奖资格。</dd>\r\n                <dd>\r\n                    4.本次活动最终解释权归飞票网所以。</dd>\r\n            </dl>\r\n        </div>\r\n    </div>\r\n    ");
	templateBuilder.Append("<div class=\"foot m_t_2\">\r\n    <div id=\"box\">\r\n        <dl class=\"BoxList\">\r\n            <dt>帮助中心</dt>\r\n            <dd>\r\n                <a href=\"http://www.feipiao.cn/help/102-40.html\">新手指南</a></dd>\r\n            <dd>\r\n                <a href=\"http://www.feipiao.cn/help/102-41.html\">常见问题</a></dd>\r\n            <dd>\r\n                <a href=\"http://www.feipiao.cn/help/102-43.html\">用户协议</a></dd>\r\n            <dd>\r\n                <a href=\"http://www.feipiao.cn/help/102-44.html\">隐私声明</a></dd>\r\n        </dl>\r\n        <div class=\"fl1\">\r\n            <img src=\"http://www.feipiao.cn/image/foot_02.gif\" /></div>\r\n        <dl class=\"BoxList\">\r\n            <dt>关注飞票网</dt>\r\n            <dd>\r\n                <a href=\"subscribe.html\">邮件订阅</a></dd>\r\n            <dd>\r\n                <a href=\"http://e.weibo.com/feipiaowang\" target=\"_blank\">飞票新浪微博</a></dd>\r\n            <dd>\r\n                <a href=\"http://t.qq.com/feipiaowang\">飞票腾讯微博</a></dd>\r\n        </dl>\r\n        <div class=\"fl1\">\r\n            <img src=\"http://www.feipiao.cn/image/foot_02.gif\" /></div>\r\n        <dl class=\"BoxList\">\r\n            <dt>商务合作</dt>\r\n            <dd>\r\n                <a href=\"http://www.feipiao.cnhttp://www.feipiao.cn/help/107-62.html\">市场合作</a></dd>\r\n            <dd>\r\n                <a href=\"http://www.feipiao.cn/help/107-64.html\">分销商申请</a></dd>\r\n        </dl>\r\n        <div class=\"fl1\">\r\n            <img src=\"http://www.feipiao.cn/image/foot_02.gif\" /></div>\r\n        <dl class=\"BoxList BoxList02\">\r\n            <dt>关于我们</dt>\r\n            <dd>\r\n                <a href=\"http://www.feipiao.cn/help/106-56.html\">关于飞票网</a></dd>\r\n            <dd>\r\n                <a href=\"http://www.feipiao.cn/help/106-57.html\">公司文化</a></dd>\r\n            <dd>\r\n                <a href=\"http://www.feipiao.cn/help/106-58.html\">媒体报道</a></dd>\r\n            <dd>\r\n                <a href=\"http://www.feipiao.cn/help/106-59.html\">诚聘英才</a></dd>\r\n            <dd>\r\n                <a href=\"http://www.feipiao.cn/help/106-65.html\">联系我们</a></dd>\r\n        </dl>\r\n        <div class=\"clear\">\r\n        </div>\r\n    </div>\r\n</div>\r\n<div class=\"clear\">\r\n</div>\r\n<div class=\"foot02\">\r\n</div>\r\n<div id=\"box\">\r\n    <ul class=\"clause\">\r\n        <li class=\"tions01\" style=\"cursor: pointer;\" onclick=\"location.href='http://www.feipiao.cn/help/105-55.html';\">\r\n            <a href=\"http://www.feipiao.cn/help/105-55.html\">七天退款</a></li>\r\n        <li class=\"tions02\" style=\"cursor: pointer;\" onclick=\"location.href='http://www.feipiao.cn/help/105-55.html';\">\r\n            <a href=\"http://www.feipiao.cn/help/105-55.html\">赠送保险</a></li>\r\n        <li class=\"tions03\" style=\"cursor: pointer;\" onclick=\"location.href='http://www.feipiao.cn/help/105-55.html';\">\r\n            <a href=\"http://www.feipiao.cn/help/105-55.html\">支持过期退款</a></li>\r\n        <div class=\"clear\">\r\n        </div>\r\n    </ul>\r\n    <h4 class=\"copyright\">\r\n        Copyright ©2010-2013 Feipiao.cn. 上海白浪游国际旅行社有限公司 版权所有<a href=\"http://www.miibeian.gov.cn/\">沪ICP备10202421号-1</a>&nbsp;&nbsp;\r\n        <script src=\"http://s15.cnzz.com/stat.php?id=4654164&web_id=4654164&show=pic\" language=\"JavaScript\"></");
	templateBuilder.Append("script>\r\n\r\n        <script type=\"text/javascript\">\r\n	var _bdhmProtocol = ((\"https:\" == document.location.protocol) ? \" https://\" : \" http://\");\r\n	document.write(unescape(\"%3Cscript src='\" + _bdhmProtocol + \"hm.baidu.com/h.js%3Fc488bec47c5c1c3ab46f5cc7d5eb14d5' type='text/javascript'%3E%3C/script%3E\"));\r\n        </");
	templateBuilder.Append("script>\r\n\r\n    </h4>\r\n    <ul class=\"copyright_bottom\">\r\n        <!--<li><script src=\"http://kxlogo.knet.cn/seallogo.dll?sn=e13013031010039047lndo000000&size=4\"></");
	templateBuilder.Append("script></li>-->\r\n        <li>\r\n\r\n            <script src=\"https://kxlogo.knet.cn/seallogo.dll?sn=e13013031010039047lndo000000&size=3\"></");
	templateBuilder.Append("script>\r\n\r\n        </li>\r\n        <!--li><a href=\"#\"><img src=\"template/feipiao/image/foto01.jpg\" width=\"117\" height=\"43\"></a></li-->\r\n        <li><a href=\"http://www.miibeian.gov.cn/\" target=\"_blank\">\r\n            <img src=\"http://www.feipiao.cn/image/foto02.jpg\" width=\"120\" height=\"43\"></a></li>\r\n        <li><a href=\"http://www.sgs.gov.cn/lz/licenseLink.do?method=licenceView&entyId=20130129102046671\">\r\n            <img src=\"http://www.feipiao.cn/image/foto03.jpg\" width=\"119\" height=\"43\"></a></li>\r\n        <li><a href=\"http://www.cyberpolice.cn/wfjb/\">\r\n            <img src=\"http://www.feipiao.cn/image/foto04.jpg\" width=\"120\" height=\"43\"></a></li>\r\n        <li><a href=\"http://www.alipay.com/\">\r\n            <img src=\"http://www.feipiao.cn/image/foto05.jpg\" width=\"118\" height=\"43\"></a></li>\r\n        <div class=\" clear\">\r\n        </div>\r\n    </ul>\r\n</div>\r\n");

	templateBuilder.Append("\r\n</body>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
