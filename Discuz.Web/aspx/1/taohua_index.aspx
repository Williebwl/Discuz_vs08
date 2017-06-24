<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="Discuz.Web.taohua_index" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="Discuz.Common" %>
<%@ Import namespace="Discuz.Forum" %>
<%@ Import namespace="Discuz.Entity" %>
<%@ Import namespace="Discuz.Config" %>

<script runat="server">
override protected void OnInit(EventArgs e)
{

	/* 
		This page was created by Discuz!NT Template Engine at 2013/04/16 17:01:32.
		本页面代码由Discuz!NT模板引擎生成于 2013/04/16 17:01:32. 
	*/

	base.OnInit(e);

	templateBuilder.Capacity = 220000;
	templateBuilder.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n    <title>第23届上海市桃花节活动</title>\r\n    <link href=\"");
	templateBuilder.Append(cssdir.ToString());
	templateBuilder.Append("/taohua.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n    <link href=\"");
	templateBuilder.Append(cssdir.ToString());
	templateBuilder.Append("/top-nav.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n    <link href=\"");
	templateBuilder.Append(cssdir.ToString());
	templateBuilder.Append("/bssom.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n    <link href=\"");
	templateBuilder.Append(cssdir.ToString());
	templateBuilder.Append("/fot.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append(config.Jqueryurl.ToString().Trim());
	templateBuilder.Append("\"></");
	templateBuilder.Append("script>\r\n\r\n    <script type=\"text/javascript\">\r\n      \r\n      function SearchFocus(){\r\n          var topsearch=$('#txt_topsearch');\r\n          if(topsearch.val()=='景区或酒店名称')\r\n          {\r\n            topsearch.val(\"\")\r\n          }\r\n        }\r\n\r\n        function SearchBlur(){\r\n          var topsearch=$('#txt_topsearch');\r\n          if(topsearch.val()==''){\r\n            topsearch.val(\"景区或酒店名称\");\r\n          }\r\n        }\r\n    </");
	templateBuilder.Append("script>\r\n\r\n    <script type=\"text/javascript\">\r\n<!--\r\nfunction MM_preloadImages() { //v3.0\r\n  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();\r\n    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)\r\n    if (a[i].indexOf(\"#\")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}\r\n}\r\n\r\nfunction MM_swapImgRestore() { //v3.0\r\n  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;\r\n}\r\n\r\nfunction MM_findObj(n, d) { //v4.01\r\n  var p,i,x;  if(!d) d=document; if((p=n.indexOf(\"?\"))>0&&parent.frames.length) {\r\n    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}\r\n  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];\r\n  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);\r\n  if(!x && d.getElementById) x=d.getElementById(n); return x;\r\n}\r\n\r\nfunction MM_swapImage() { //v3.0\r\n  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)\r\n   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}\r\n}\r\n//-->\r\n    </");
	templateBuilder.Append("script>\r\n\r\n</head>\r\n<body>\r\n    <body onload=\"MM_preloadImages('");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/index_top_08.jpg','");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/index_top_07.jpg','");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/index_top_06.jpg')\">\r\n        ");
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

	templateBuilder.Append("\r\n        <div class=\"pink\">\r\n            <div class=\"index_backg\">\r\n                <div id=\"xianzi_box\">\r\n                    <div class=\"top_iru\">\r\n                    </div>\r\n                    <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/index_top_04.jpg\" width=\"990\" height=\"177\" />\r\n                </div>\r\n            </div>\r\n            <div class=\"index_backg02\">\r\n                <div id=\"xianzi_box\">\r\n                    <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/index_top_05.jpg\" width=\"990\" height=\"227\" /></div>\r\n            </div>\r\n            <div class=\"index_backg03\">\r\n                <div id=\"xianzi_box\">\r\n                    <li id=\"menuleft\" style=\"width:316px; overflow:hidden\"><a href=\"http://bbs.feipiao.cn/taohua_5000.aspx\" target=\"_blank\"><img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/index_top_07.jpg\" width=\"316\" height=\"232\" border=\"0\"/></a></li>\r\n                    <li id=\"menuleft\" style=\"width:336px; overflow:hidden\"><a href=\"http://bbs.feipiao.cn/userlottery.aspx\" target=\"_blank\"><img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/index_top_08.jpg\" width=\"336\" height=\"232\" border=\"0\"/></a></li>\r\n                    <li id=\"menuleft\" style=\"width:338px; overflow:hidden\"><a href=\"http://bbs.feipiao.cn/taohua_xianzi.aspx\" target=\"_blank\"><img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/index_top_09.jpg\" width=\"338\" height=\"232\" border=\"0\"/></a></li>\r\n                </div>\r\n                <div class=\"clear\"></div>\r\n            </div>\r\n            <div id=\"xianzi_box\">\r\n                <div>\r\n                    <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/index_top_06.jpg\" width=\"990\" height=\"188\" /></div>\r\n                <ul class=\"youjity\">\r\n                    <li style=\"width: 332px;\">\r\n                        <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/indextui_03.jpg\" width=\"332\" height=\"529\" border=\"0\"\r\n                            usemap=\"#Map6\" />\r\n                        <map name=\"Map6\" id=\"Map6\">\r\n                            <area shape=\"rect\" coords=\"204,461,320,519\" href=\"http://www.feipiao.cn/index.php?act=group_info&amp;id=781\"\r\n                                target=\"_blank\" />\r\n                        </map>\r\n                    </li>\r\n                    <li style=\"width: 323px;\">\r\n                        <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/indextui_04.jpg\" width=\"323\" height=\"529\" border=\"0\"\r\n                            usemap=\"#Map7\" />\r\n                        <map name=\"Map7\" id=\"Map7\">\r\n                            <area shape=\"rect\" coords=\"198,461,306,513\" href=\"http://www.feipiao.cn/index.php?act=group_info&amp;id=780\"\r\n                                target=\"_blank\" />\r\n                        </map>\r\n                    </li>\r\n                    <li>\r\n                        <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/indextui_05.jpg\" width=\"335\" height=\"529\" border=\"0\"\r\n                            usemap=\"#Map8\" />\r\n                        <map name=\"Map8\" id=\"Map8\">\r\n                            <area shape=\"rect\" coords=\"193,464,308,521\" href=\"http://www.feipiao.cn/index.php?act=group_info&amp;id=779\"\r\n                                target=\"_blank\" />\r\n                        </map>\r\n                    </li>\r\n                </ul>\r\n                <ul class=\"youjity02\">\r\n                    <li style=\"width: 332px;\">\r\n                        <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/indextui_07.jpg\" width=\"332\" height=\"580\" border=\"0\"\r\n                            usemap=\"#Map5\" />\r\n                        <map name=\"Map5\" id=\"Map5\">\r\n                            <area shape=\"rect\" coords=\"202,504,320,556\" href=\"http://www.feipiao.cn/index.php?act=group_info&amp;id=782\"\r\n                                target=\"_blank\" />\r\n                        </map>\r\n                    </li>\r\n                    <li style=\"width: 323px;\">\r\n                        <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/indextui_08.jpg\" width=\"323\" height=\"580\" /></li>\r\n                    <li>\r\n                        <dl class=\"dongtai\">\r\n                            <dt>\r\n                                <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/dongtai.gif\" /></dt>\r\n                            <dd>\r\n                                <span>tina</span>1分钟前购买了<label>合庆有机桃园门票</label></dd>\r\n                            <dd>\r\n                                <span>maroram</span>35分钟前购买了<label>滨海桃园门票</label></dd>\r\n                            <dd>\r\n                                <span>zoeyzcw</span>36分钟前购买了<label>新场桃园门票</label></dd>\r\n                            <dd>\r\n                                <span>可乐扬</span>39分钟前购买了<label>新场桃园门票</label></dd>\r\n                            <dd>\r\n                                <span>葡萄_酱</span>50分钟前购买了<label>大团桃园门票</label></dd>\r\n                            <dd>\r\n                                <span>Ruby_1203</span>1小时前购买了<label>新场桃园门票</label></dd>\r\n                            <dt style=\"padding-top: 20px;\">\r\n                                <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/xiazai.gif\" /></dt>\r\n                            <div class=\"gonglxz\">\r\n                                <h2>\r\n                                    赏花八卦占卜篇</h2>\r\n                                花开几时谁人知，关注花期预测：\r\n                                <br />\r\n                                兴匆匆扑了个空没瞧见桃花，是每个赏花客最大的遗憾，如何选择靠谱的访花日其实很简单： 3月起上海电视台《新闻坊》、浦东旅游会展网、“乐游上海”微博、全市大型广告LED公益时段、社区公益屏等渠道将会定期发布花期预报，可为大家提供便利的、权威的赏花信息哦，敬请关注！</div>\r\n                        </dl>\r\n                    </li>\r\n                    <div class=\"clear\">\r\n                    </div>\r\n                </ul>\r\n                <div>\r\n                    <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/indextui_10.jpg\" /></div>\r\n                <ul class=\"youjity03\">\r\n                    <li style=\"width: 206px;\">\r\n                        <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/indextui_11.jpg\" width=\"206\" height=\"446\" border=\"0\"\r\n                            usemap=\"#Map\" />\r\n                        <map name=\"Map\" id=\"Map\">\r\n                            <area shape=\"rect\" coords=\"36,327,182,383\" href=\"http://bbs.feipiao.cn/taohuaipad.aspx\"\r\n                                target=\"_blank\" />\r\n                        </map>\r\n                    </li>\r\n                    <li style=\"width: 258px;\">\r\n                        <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/indextui_12.jpg\" width=\"258\" height=\"446\" /></li>\r\n                    <li style=\"width: 259px;\">\r\n                        <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/indextui_13.jpg\" width=\"259\" height=\"446\" /></li>\r\n                    <li>\r\n                        <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/indextui_14.jpg\" width=\"267\" height=\"446\" /></li>\r\n                </ul>\r\n                <div>\r\n                    <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/indextui_15.jpg\" /></div>\r\n                <ul class=\"youjity04\">\r\n                    <li style=\"width: 206px;\">\r\n                        <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/indextui_16.jpg\" width=\"206\" height=\"432\" /></li>\r\n                    <li style=\"width: 258px;\">\r\n                        <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/indextui_17.jpg\" width=\"258\" height=\"432\" /></li>\r\n                    <li style=\"width: 259px;\">\r\n                        <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/indextui_18.jpg\" width=\"259\" height=\"432\" /></li>\r\n                    <li>\r\n                        <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/indextui_19.jpg\" width=\"267\" height=\"432\" /></li>\r\n                </ul>\r\n                <div>\r\n                    <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/indextui_20.jpg\" width=\"990\" height=\"74\" /></div>\r\n                <ul class=\"youjity05\">\r\n                    <li>\r\n                        <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/indextui_21.jpg\" width=\"990\" height=\"191\" border=\"0\"\r\n                            usemap=\"#Map4\" />\r\n                        <map name=\"Map4\" id=\"Map4\">\r\n                            <area shape=\"rect\" coords=\"812,141,952,181\" href=\"http://www.feipiao.cn/index.php?act=group_info&amp;id=778\"\r\n                                target=\"_blank\" />\r\n                        </map>\r\n                    </li>\r\n                    <li style=\"line-height: 186px;\">\r\n                        <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/indextui_22.jpg\" width=\"990\" height=\"186\" border=\"0\"\r\n                            usemap=\"#Map2Map\" />\r\n                        <map name=\"Map2Map\" id=\"Map2Map\">\r\n                            <area shape=\"rect\" coords=\"53,138,187,177\" href=\"http://www.feipiao.cn/index.php?act=group_info&amp;id=776\"\r\n                                target=\"_blank\" />\r\n                        </map>\r\n                    </li>\r\n                    <li style=\"height: 186px;\">\r\n                        <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/indextui_23.jpg\" width=\"990\" height=\"204\" border=\"0\"\r\n                            usemap=\"#Map2\" />\r\n                        <map name=\"Map2\" id=\"Map2\">\r\n                            <area shape=\"rect\" coords=\"813,140,947,179\" href=\"http://www.feipiao.cn/index.php?act=group_info&amp;id=777\"\r\n                                target=\"_blank\" />\r\n                        </map>\r\n                    </li>\r\n                    <div class=\"clear\">\r\n                    </div>\r\n                </ul>\r\n                <div>\r\n                    <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/indextui_24.jpg\" width=\"990\" height=\"217\" /></div>\r\n                <ul class=\"youjity\">\r\n                    <li style=\"width: 321px;\">\r\n                        <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/indextui_25.jpg\" width=\"321\" height=\"487\" /></li>\r\n                    <li style=\"width: 345px;\">\r\n                        <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/indextui_26.jpg\" width=\"345\" height=\"487\" /></li>\r\n                    <li>\r\n                        <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/indextui_27.jpg\" width=\"324\" height=\"487\" /></li>\r\n                    <div class=\"clear\">\r\n                    </div>\r\n                </ul>\r\n            </div>\r\n            <div class=\"flaoy\">\r\n                <div id=\"xianzi_box\">\r\n                    <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/indextui_29.jpg\" /></div>\r\n            </div>\r\n            <div class=\"flaoy_botom\">\r\n                <ul>\r\n                    <li>\r\n                        <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/meiti01.gif\" vspace=\"20\" /></li>\r\n                    <li>\r\n                        <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/meiti02.gif\" /></li>\r\n                    <li>\r\n                        <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/meiti03.gif\" /></li>\r\n                    <li>\r\n                        <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/meiti04.gif\" /></li>\r\n                    <li>\r\n                        <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/meiti05.gif\" /></li>\r\n                    <li>\r\n                        <img src=\"");
	templateBuilder.Append(imagedir.ToString());
	templateBuilder.Append("/bssom_image/meiti06.gif\" /></li>\r\n                    <div class=\"clear\">\r\n                    </div>\r\n                </ul>\r\n            </div>\r\n            <div class=\"clear\">\r\n            </div>\r\n        </div>\r\n        ");
	templateBuilder.Append("<div class=\"foot m_t_2\">\r\n    <div id=\"box\">\r\n        <dl class=\"BoxList\">\r\n            <dt>帮助中心</dt>\r\n            <dd>\r\n                <a href=\"http://www.feipiao.cn/help/102-40.html\">新手指南</a></dd>\r\n            <dd>\r\n                <a href=\"http://www.feipiao.cn/help/102-41.html\">常见问题</a></dd>\r\n            <dd>\r\n                <a href=\"http://www.feipiao.cn/help/102-43.html\">用户协议</a></dd>\r\n            <dd>\r\n                <a href=\"http://www.feipiao.cn/help/102-44.html\">隐私声明</a></dd>\r\n        </dl>\r\n        <div class=\"fl1\">\r\n            <img src=\"http://www.feipiao.cn/image/foot_02.gif\" /></div>\r\n        <dl class=\"BoxList\">\r\n            <dt>关注飞票网</dt>\r\n            <dd>\r\n                <a href=\"subscribe.html\">邮件订阅</a></dd>\r\n            <dd>\r\n                <a href=\"http://e.weibo.com/feipiaowang\" target=\"_blank\">飞票新浪微博</a></dd>\r\n            <dd>\r\n                <a href=\"http://t.qq.com/feipiaowang\">飞票腾讯微博</a></dd>\r\n        </dl>\r\n        <div class=\"fl1\">\r\n            <img src=\"http://www.feipiao.cn/image/foot_02.gif\" /></div>\r\n        <dl class=\"BoxList\">\r\n            <dt>商务合作</dt>\r\n            <dd>\r\n                <a href=\"http://www.feipiao.cnhttp://www.feipiao.cn/help/107-62.html\">市场合作</a></dd>\r\n            <dd>\r\n                <a href=\"http://www.feipiao.cn/help/107-64.html\">分销商申请</a></dd>\r\n        </dl>\r\n        <div class=\"fl1\">\r\n            <img src=\"http://www.feipiao.cn/image/foot_02.gif\" /></div>\r\n        <dl class=\"BoxList BoxList02\">\r\n            <dt>关于我们</dt>\r\n            <dd>\r\n                <a href=\"http://www.feipiao.cn/help/106-56.html\">关于飞票网</a></dd>\r\n            <dd>\r\n                <a href=\"http://www.feipiao.cn/help/106-57.html\">公司文化</a></dd>\r\n            <dd>\r\n                <a href=\"http://www.feipiao.cn/help/106-58.html\">媒体报道</a></dd>\r\n            <dd>\r\n                <a href=\"http://www.feipiao.cn/help/106-59.html\">诚聘英才</a></dd>\r\n            <dd>\r\n                <a href=\"http://www.feipiao.cn/help/106-65.html\">联系我们</a></dd>\r\n        </dl>\r\n        <div class=\"clear\">\r\n        </div>\r\n    </div>\r\n</div>\r\n<div class=\"clear\">\r\n</div>\r\n<div class=\"foot02\">\r\n</div>\r\n<div id=\"box\">\r\n    <ul class=\"clause\">\r\n        <li class=\"tions01\" style=\"cursor: pointer;\" onclick=\"location.href='http://www.feipiao.cn/help/105-55.html';\">\r\n            <a href=\"http://www.feipiao.cn/help/105-55.html\">七天退款</a></li>\r\n        <li class=\"tions02\" style=\"cursor: pointer;\" onclick=\"location.href='http://www.feipiao.cn/help/105-55.html';\">\r\n            <a href=\"http://www.feipiao.cn/help/105-55.html\">赠送保险</a></li>\r\n        <li class=\"tions03\" style=\"cursor: pointer;\" onclick=\"location.href='http://www.feipiao.cn/help/105-55.html';\">\r\n            <a href=\"http://www.feipiao.cn/help/105-55.html\">支持过期退款</a></li>\r\n        <div class=\"clear\">\r\n        </div>\r\n    </ul>\r\n    <h4 class=\"copyright\">\r\n        Copyright ©2010-2013 Feipiao.cn. 上海白浪游国际旅行社有限公司 版权所有<a href=\"http://www.miibeian.gov.cn/\">沪ICP备10202421号-1</a>&nbsp;&nbsp;\r\n        <script src=\"http://s15.cnzz.com/stat.php?id=4654164&web_id=4654164&show=pic\" language=\"JavaScript\"></");
	templateBuilder.Append("script>\r\n\r\n        <script type=\"text/javascript\">\r\n	var _bdhmProtocol = ((\"https:\" == document.location.protocol) ? \" https://\" : \" http://\");\r\n	document.write(unescape(\"%3Cscript src='\" + _bdhmProtocol + \"hm.baidu.com/h.js%3Fc488bec47c5c1c3ab46f5cc7d5eb14d5' type='text/javascript'%3E%3C/script%3E\"));\r\n        </");
	templateBuilder.Append("script>\r\n\r\n    </h4>\r\n    <ul class=\"copyright_bottom\">\r\n        <!--<li><script src=\"http://kxlogo.knet.cn/seallogo.dll?sn=e13013031010039047lndo000000&size=4\"></");
	templateBuilder.Append("script></li>-->\r\n        <li>\r\n\r\n            <script src=\"https://kxlogo.knet.cn/seallogo.dll?sn=e13013031010039047lndo000000&size=3\"></");
	templateBuilder.Append("script>\r\n\r\n        </li>\r\n        <!--li><a href=\"#\"><img src=\"template/feipiao/image/foto01.jpg\" width=\"117\" height=\"43\"></a></li-->\r\n        <li><a href=\"http://www.miibeian.gov.cn/\" target=\"_blank\">\r\n            <img src=\"http://www.feipiao.cn/image/foto02.jpg\" width=\"120\" height=\"43\"></a></li>\r\n        <li><a href=\"http://www.sgs.gov.cn/lz/licenseLink.do?method=licenceView&entyId=20130129102046671\">\r\n            <img src=\"http://www.feipiao.cn/image/foto03.jpg\" width=\"119\" height=\"43\"></a></li>\r\n        <li><a href=\"http://www.cyberpolice.cn/wfjb/\">\r\n            <img src=\"http://www.feipiao.cn/image/foto04.jpg\" width=\"120\" height=\"43\"></a></li>\r\n        <li><a href=\"http://www.alipay.com/\">\r\n            <img src=\"http://www.feipiao.cn/image/foto05.jpg\" width=\"118\" height=\"43\"></a></li>\r\n        <div class=\" clear\">\r\n        </div>\r\n    </ul>\r\n</div>\r\n");

	templateBuilder.Append("\r\n    </body>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
