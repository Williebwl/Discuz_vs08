using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using Discuz.Forum;

namespace Discuz.Web.Handler
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class taohua_xianziHandler : IHttpHandler
    {

        HttpRequest Request;
        HttpResponse Response;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Request = context.Request;
            Response = context.Response;
            switch (Request["operType"])
            {
                case "verifyvote":
                    DateTime begin = DateTime.Parse(Discuz.Common.ConfigOperator.ConfigReadValue("startvotetime"));
                    DateTime end = DateTime.Parse(Discuz.Common.ConfigOperator.ConfigReadValue("endvotetime")).AddDays(1);
                    if (DateTime.Now < begin)
                    {
                        Response.Write("{\"result\":\"0\",\"msg\":\"投票太早了，投票时间为：" + begin.ToString("yyyy年MM月dd日") + "到" + end.AddDays(-1).ToString("yyyy年MM月dd日") + "\"}");
                    }
                    else if (end < DateTime.Now)
                    {
                        Response.Write("{\"result\":\"0\",\"msg\":\"投票来晚了，投票时间为：" + begin.ToString("yyyy年MM月dd日") + "到" + end.AddDays(-1).ToString("yyyy年MM月dd日") + "\"}");
                    }
                    else
                    {
                        //判断指定的IP是否已投过票了,如果已经投过了,则弹出提示对话框
                        string UserIP = Request.UserHostAddress.ToString();
                        HttpCookie oldCookie = Request.Cookies["userIP"];
                        if (oldCookie == null)
                        {
                            //定义新的Cookie对象
                            HttpCookie newCookie = new HttpCookie("IPaddress");
                            newCookie.Expires = DateTime.Now.AddMinutes(5);
                            //添加新的Cookie变量IPaddress，值为UserIP
                            newCookie.Value = UserIP;
                            //将变量写入Cookie文件中
                            Response.AppendCookie(newCookie);
                            Response.Write("{\"result\":\"1\"}");
                        }
                        else
                        {
                            string userIP = oldCookie.Values["IPaddress"];
                            if (UserIP.Trim() == userIP.Trim())
                            {
                                Response.Write("{\"result\":\"0\",\"msg\":\"一个IP地址只能投一次票，谢谢您的参与！\"}");
                            }
                            else
                            {
                                //定义新的Cookie对象
                                HttpCookie newCookie = new HttpCookie("IPaddress");
                                newCookie.Expires = DateTime.Now.AddMinutes(5);
                                //添加新的Cookie变量IPaddress，值为UserIP
                                newCookie.Value = UserIP;
                                //将变量写入Cookie文件中
                                Response.AppendCookie(newCookie);
                                Response.Write("{\"result\":\"1\"}");
                            }
                        }
                    }
                    break;
                case "vote":
                    if (Attachments.UpdatePicVote(int.Parse(Request["Aid"]), string.Empty) > 0)
                    {
                        CookiesHelper.AddNoDomainCoolie("userIP", "IPaddress", CookiesHelper.GetCookieValue("IPaddress"), 60 * 24);
                        Response.Write("{\"result\":\"1\",\"msg\":\"投票成功，谢谢您的参与！\"}");
                    }
                    else
                    {
                        Response.Write("{\"result\":\"0\",\"msg\":\"投票失败,请稍后重试！\"}");
                    }

                    break;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
