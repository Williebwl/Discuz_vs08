using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Discuz.Forum;
using Discuz.Common;

namespace Discuz.Web
{
    public class taohuavote : PageBase
    {

        #region 页面变量
        /// <summary>
        /// 投票实体
        /// </summary>
        public DataRow dr_vote;
        /// <summary>
        /// 当前页码
        /// </summary>
        public int pageid = DNTRequest.GetInt("page", 1);
        /// <summary>
        /// 总投票数
        /// </summary>
        public int totalvote;
        /// <summary>
        /// 分页页数
        /// </summary>
        public int pagecount;
        /// <summary>
        /// 分页页码链接
        /// </summary>
        public string pagenumbers;
        /// <summary>
        /// 美图ID
        /// </summary>
        public int aid = 0;
        /// <summary>
        /// 会员ID
        /// </summary>
        public int uid = 0;
        public int prepage = 0;//上一页
        public int nexpage = 0;//下一页
        public int issuccess = 0;//是否成功(0:失败1:成功)
        public string errormessage = string.Empty;
        public bool IsPostBack = true;//是否首次加载
        #endregion
        protected override void ShowPage()
        {
            pagetitle = "投票";

            //修正请求页数中可能的错误
            pageid = pageid < 1 ? 1 : pageid;
            aid = DNTRequest.GetInt("aid", 0);
            uid = DNTRequest.GetInt("uid", 0);
            Attachments.UpdateAttachmentviewnum(aid);

            DataSet ds = Attachments.GetVotelistByUid(aid, uid, pageid, 1, ref totalvote);
            if (ds != null && ds.Tables.Count > 0 & ds.Tables[0].Rows.Count > 0)
            {
                dr_vote = ds.Tables[0].Rows[0];
            }
            else
            {
                SetUrl("taohua_xianzi.aspx");
                SetMetaRefresh();
                AddErrLine("没有信息可读取！");
                return;
            }
            //获取总页数
            pagecount = totalvote % 1 == 0 ? totalvote / 1 : totalvote / 1 + 1;
            pagecount = pagecount == 0 ? 1 : pagecount;

            pageid = pageid > pagecount ? pagecount : pageid;

            prepage = pageid - 1;
            nexpage = pageid + 1;

            prepage = prepage == 0 ? 1 : prepage;
            prepage = prepage > pagecount ? pagecount : prepage;

            nexpage = nexpage == 0 ? 1 : nexpage;
            nexpage = nexpage > pagecount ? pagecount : nexpage;

            //得到页码链接
            pagenumbers = Utils.GetPageNumbers(pageid, pagecount, string.Format("taohuavote.aspx{0}", string.Format("?uid={0}", uid)), 8);

            //如果是POST提交...
            if (ispost)
            {
                DateTime begin = DateTime.Parse(Discuz.Common.ConfigOperator.ConfigReadValue("startvotetime"));
                DateTime end = DateTime.Parse(Discuz.Common.ConfigOperator.ConfigReadValue("endvotetime")).AddDays(1);
                if (DateTime.Now < begin || end < DateTime.Now)
                {
                    SetUrl("taohua_xianzi.aspx");
                    SetMetaRefresh();
                    AddErrLine("投票时间为：" + begin.ToString("yyyy年MM月dd日") + "到" + end.AddDays(-1).ToString("yyyy年MM月dd日"));
                    return;
                }
                else
                {
                    string UserIP = HttpContext.Current.Request.UserHostAddress.ToString();
                    HttpCookie oldCookie = HttpContext.Current.Request.Cookies["userIP"];
                    if (oldCookie == null)
                    {
                        //定义新的Cookie对象
                        HttpCookie newCookie = new HttpCookie("IPaddress");
                        newCookie.Expires = DateTime.Now.AddMinutes(5);
                        //添加新的Cookie变量IPaddress，值为UserIP
                        newCookie.Value = UserIP;
                        //将变量写入Cookie文件中
                        HttpContext.Current.Response.AppendCookie(newCookie);
                    }
                    else
                    {
                        string userIP = oldCookie.Values["IPaddress"];
                        if (UserIP.Trim() == userIP.Trim())
                        {
                            SetUrl("taohua_xianzi.aspx");
                            SetMetaRefresh();
                            AddErrLine("一个IP地址只能投一次票，谢谢您的参与！");
                            return;
                        }
                        else
                        {
                            //定义新的Cookie对象
                            HttpCookie newCookie = new HttpCookie("IPaddress");
                            newCookie.Expires = DateTime.Now.AddMinutes(5);
                            //添加新的Cookie变量IPaddress，值为UserIP
                            newCookie.Value = UserIP;
                            //将变量写入Cookie文件中
                            HttpContext.Current.Response.AppendCookie(newCookie);
                        }
                    }

                    //string checkCode = CookiesHelper.GetCookieValue("CheckCode");
                    //if (checkCode.Equals(DNTRequest.GetString("vcode")))
                    //{
                    aid = DNTRequest.GetInt("hidaid", 0);
                    if (Attachments.UpdatePicVote(aid, DNTRequest.GetString("txt_comment")) > 0)
                    {
                        //aid = 0;
                        //dr_vote = Attachments.GetVotelistByUid(aid, uid, pageid, 1, ref totalvote).Tables[0].Rows[0];
                        CookiesHelper.AddNoDomainCoolie("userIP", "IPaddress", CookiesHelper.GetCookieValue("IPaddress"), 60 * 24);
                        AddMsgLine("投票成功，谢谢您的参与！");
                        //SetUrl(forumpath + "taohuavote.aspx" + HttpContext.Current.Request.Url.PathAndQuery.Substring(HttpContext.Current.Request.Url.PathAndQuery.IndexOf("?")) + "&aid=" + aid);
                        SetUrl(forumpath + "taohuavote.aspx?uid=" + uid + "&aid=" + aid);
                        SetMetaRefresh();
                        SetShowBackLink(false);
                    }
                    else
                    {
                        AddErrLine("投票失败,请稍后重试！");
                        SetUrl("taohua_xianzi.aspx");
                        SetMetaRefresh(5);
                        SetShowBackLink(true);
                    }
                    //}
                    //else
                    //{
                    //    errormessage = "验证码错误！";
                    //}
                }
            }
        }
    }
}
