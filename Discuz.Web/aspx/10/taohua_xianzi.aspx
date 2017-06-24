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
		This page was created by Discuz!NT Template Engine at 2013-3-17 15:46:24.
		本页面代码由Discuz!NT模板引擎生成于 2013-3-17 15:46:24. 
	*/

	base.OnInit(e);

	templateBuilder.Capacity = 220000;
	templateBuilder.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n    <title>");
	templateBuilder.Append(pagetitle.ToString());
	templateBuilder.Append(" - ");
	templateBuilder.Append(config.Forumtitle.ToString().Trim());
	templateBuilder.Append(" ");
	templateBuilder.Append(config.Seotitle.ToString().Trim());
	templateBuilder.Append(" </title>\r\n    <link rel=\"stylesheet\" href=\"");
	templateBuilder.Append(cssdir.ToString());
	templateBuilder.Append("/dnt.css\" type=\"text/css\" media=\"all\" />\r\n    <link href=\"");
	templateBuilder.Append(cssdir.ToString());
	templateBuilder.Append("/taohua.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append(config.Jqueryurl.ToString().Trim());
	templateBuilder.Append("\"></");
	templateBuilder.Append("script>\r\n\r\n    <script src=\"");
	templateBuilder.Append(jsdir.ToString());
	templateBuilder.Append("/taohua_xianzi.js?t=20130315.js\" type=\"text/javascript\"></");
	templateBuilder.Append("script>\r\n\r\n</head>\r\n<body>\r\n    <div class=\"purple\">\r\n        <div class=\"backtop\">\r\n            <div id=\"xianzi_box\">\r\n                <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/top_02.jpg\" border=\"0\" />\r\n            </div>\r\n        </div>\r\n        <div class=\"backtop02\">\r\n            <div id=\"xianzi_box\">\r\n                <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/top_04.jpg\" />\r\n                <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/top_05.jpg\" />\r\n            </div>\r\n        </div>\r\n        <div class=\"backtop03\">\r\n            <div id=\"xianzi_box\">\r\n                <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/top_06.jpg\" width=\"989\" height=\"306\" border=\"0\" usemap=\"#Map\" />\r\n                <map name=\"Map\" id=\"Map\">\r\n                    <area shape=\"rect\" coords=\"81,226,219,251\" href=\"#\" />\r\n                    <area shape=\"rect\" coords=\"434,258,570,286\" href=\"taohua_ipad.html\" target=\"_blank\" />\r\n                    <area shape=\"rect\" coords=\"408,212,409,213\" href=\"#\" />\r\n                </map>\r\n                <img src=\"");
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
	templateBuilder.Append("/stpe_xian.gif\" /></div>\r\n                    <dl class=\"instructions\">\r\n                        <dt>\r\n                            <h2>\r\n                                规则:</h2>\r\n                            时间：2013-3-15 至 2013-4-28 </dt>\r\n                        <dd style=\"font-weight: bold; font-size: 14px;\">\r\n                            报名条件：</dd>\r\n                        <dd>\r\n                            1.需提供本人正面与桃花的合影照片；</dd>\r\n                        <dd>\r\n                            2.照片为素颜照或淡妆照，浓妆不予入选；</dd>\r\n                        <dd>\r\n                            3.照片经图形软件过度处理失真不予入选；</dd>\r\n                        <dd>\r\n                            4.报名者须女性，年龄在17岁至35岁之间。</dd>\r\n                    </dl>\r\n                </div>\r\n                <div class=\"sign_up\">\r\n                    <ul class=\"sign_bot\">\r\n                        <li><span>一等奖 1名</span></li>\r\n                        <li>奖励10万元旅游基金</li>\r\n                        <li><span>二等奖 2名</span></li>\r\n                        <li>奖励5000元旅游基金</li>\r\n                        <li><span>三等奖 3名</span></li>\r\n                        <li>奖励2000元旅游基金</li>\r\n                        <div class=\"clear\">\r\n                        </div>\r\n                    </ul>\r\n                    <div class=\"canjia_aniu\">\r\n                        <a href=\"#\" target=\"_blank\">\r\n                            <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/cjanniu.gif\" border=\"0\" /></a></div>\r\n                </div>\r\n                <div class=\"clear\">\r\n                </div>\r\n                <div class=\"pingxuan\">\r\n                    <h2>\r\n                        评选规则：</h2>\r\n                    评选在报名结束后的规定时间内接受会员的投票，每位网民只能投票一次重复无效，各类排行榜以会员得到的有效选票总数由高到低排列，实时动态显示。</div>\r\n            </div>\r\n            <div class=\"contestants\">\r\n                <form action=\"\" method=\"get\" id=\"formsearch\" name=\"formsearch\">\r\n                <ul class=\"contestants_top\">\r\n                    <li>\r\n                        <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/cansai.gif\" width=\"311\" height=\"139\" align=\"left\" /></li>\r\n                    <li class=\"search\">\r\n                        <input name=\"txt_aid\" id=\"txt_aid\" type=\"text\" onkeyup=\"value=value.replace(/[^\\d]/g,'')\"\r\n                            value=\"");
	templateBuilder.Append(aid.ToString());
	templateBuilder.Append("\" />\r\n                        <input id=\"page\" type=\"hidden\" value=\"");
	templateBuilder.Append(pageid.ToString());
	templateBuilder.Append("\" name=\"page\" />\r\n                        <input id=\"orderby\" type=\"hidden\" value=\"");
	templateBuilder.Append(orderby.ToString());
	templateBuilder.Append("\" name=\"orderby\" />\r\n                        <input id=\"ordertype\" type=\"hidden\" value=\"");
	templateBuilder.Append(ordertype.ToString());
	templateBuilder.Append("\" name=\"ordertype\" />\r\n                        <a href=\"javascript:void(0);\" onclick=\"this.document.forms['formsearch'].submit();\">\r\n                            <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/search02.gif\" id=\"img_search\" width=\"37\" height=\"32\" align=\"absmiddle\" /></a>\r\n                    </li>\r\n                    <li style=\"margin-top: 99px;\"><a href=\"javascript:void(0);\" onclick=\"this.document.forms['formsearch'].submit();\">\r\n                        <img src=\"");
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

	templateBuilder.Append("\r\n                    <li>\r\n                        <dl>\r\n                            <dt>\r\n                                <img src=\"upload/" + vote["filename"].ToString().Trim() + "\" width=\"200\" height=\"247\" /></dt>\r\n                            <dd>\r\n                                " + vote["aid"].ToString().Trim() + "号 " + vote["title"].ToString().Trim() + "</dd>\r\n                            <dd>\r\n                            </dd>\r\n                            <dd>\r\n                                <span>已获<label>" + vote["ticketnum"].ToString().Trim() + "</label>票</span></dd>\r\n                            <dd>\r\n                                <a href=\"javascript:void(0);\" onclick=\"CheckVote(" + vote["aid"].ToString().Trim() + "," + vote["uid"].ToString().Trim() + ");\">\r\n                                    <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/toupiao.gif\" align=\"texttop\" border=\"0\" /></a></dd>\r\n                            <div class=\"clear\">\r\n                            </div>\r\n                        </dl>\r\n                    </li>\r\n                    ");
	}	//end loop

	templateBuilder.Append("\r\n                    <div class=\"clear\">\r\n                    </div>\r\n                </ul>\r\n                <!--<ul class=\"list_page\">\r\n                    <li><a href=\"#\" class=\"one\">1</a></li>\r\n                    <li><a href=\"#\">2</a></li>\r\n                    <li><a href=\"#\">3</a></li>\r\n                    <li><a href=\"#\">...</a></li>\r\n                    <li><a href=\"#\">5</a></li>\r\n                </ul>-->\r\n                <div class=\"wrap cl\">\r\n                    <div class=\"main datalist\">\r\n                        <div class=\"pages_btns cl\">\r\n                            <div class=\"pages\">\r\n                                <kbd>共");
	templateBuilder.Append(totalvote.ToString());
	templateBuilder.Append("张票</kbd>");
	templateBuilder.Append(pagenumbers.ToString());
	templateBuilder.Append("<kbd>共");
	templateBuilder.Append(pagecount.ToString());
	templateBuilder.Append("页</kbd>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n                <div class=\"clear\">\r\n                </div>\r\n            </div>\r\n            <dl class=\"Matters\">\r\n                <dt>注意事项</dt>\r\n                <dd>\r\n                    1.本次活动中的获奖信息，活动主办方将以邮件和电话联络2种方式通知获奖网友。</dd>\r\n                <dd>\r\n                    2.本次活动中获奖的网友请在收到获奖信息后，尽快回复主办方（飞票网）的获奖通知信。如在获奖信息公布10天内仍未回复确认，则视为放弃。</dd>\r\n                <dd>\r\n                    3.本次活动严谨作弊，一经发现，即取消相关参与者的获奖资格。</dd>\r\n                <dd>\r\n                    4.本次活动最终解释权归飞票网所以。</dd>\r\n            </dl>\r\n        </div>\r\n    </div>\r\n    <!--<ul class=\"foot_nav\"> <li class=\"thnv\"></li> <li class=\"thnv02\"></li> <li class=\"thnv03\"></li>\r\n    </ul>-->\r\n</body>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
