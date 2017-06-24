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
    public class vote : PageBase
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
        public string errormessage = string.Empty;
        #endregion
        protected override void ShowPage()
        {
            pagetitle = "投票";
            //修正请求页数中可能的错误
            pageid = pageid < 1 ? 1 : pageid;
            aid = DNTRequest.GetInt("aid", 0);
            uid = DNTRequest.GetInt("uid", 0);
            Attachments.UpdateAttachmentviewnum(aid);

            dr_vote = Attachments.GetVotelistByUid(aid, uid, pageid, 1, ref totalvote).Tables[0].Rows[0];

            //获取总页数
            pagecount = totalvote % 1 == 0 ? totalvote / 1 : totalvote / 1 + 1;
            pagecount = pagecount == 0 ? 1 : pagecount;

            pageid = pageid > pagecount ? pagecount : pageid;

            //得到页码链接
            pagenumbers = Utils.GetPageNumbers(pageid, pagecount, string.Format("vote.aspx{0}", string.Format("?uid={0}", uid)), 8);

            //如果是POST提交...
            if (ispost)
            {
                string checkCode = CookiesHelper.GetCookieValue("CheckCode");
                if (checkCode.Equals(DNTRequest.GetString("vcode")))
                {
                    aid = DNTRequest.GetInt("hidaid", 0);
                    if (Attachments.UpdatePicVote(aid, DNTRequest.GetString("txt_comment")) > 0)
                    {
                        aid = 0;
                        dr_vote = Attachments.GetVotelistByUid(aid, uid, pageid, 1, ref totalvote).Tables[0].Rows[0];
                        CookiesHelper.AddNoDomainCoolie("userIP", "IPaddress", CookiesHelper.GetCookieValue("IPaddress"), 60 * 24);
                        errormessage = "投票成功，谢谢您的参与！";
                    }
                    else
                    {
                        errormessage = "投票失败！";
                    }
                }
                else
                {
                    errormessage = "验证码错误！";
                }
            }
        }
    }
}
