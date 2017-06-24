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
    public class votelist : PageBase
    {
        #region 页面变量
        /// <summary>
        /// 投票列表
        /// </summary>
        public DataTable vote_list = new DataTable();
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
        /// 页大小
        /// </summary>
        public int pagesize = 10;
        /// <summary>
        /// 分页页码链接
        /// </summary>
        public string pagenumbers;
        #endregion

        protected override void ShowPage()
        {
            pagetitle = "投票列表";

            string orderby = DNTRequest.GetString("orderby").Trim();
            //进行参数过滤
            if (!Utils.InArray(orderby, "0,1,2"))
                orderby = "0";

            string ordertype = DNTRequest.GetString("ordertype").Trim();
            //进行参数过滤      
            if (!ordertype.Equals("desc") && !ordertype.Equals("asc"))
                ordertype = "desc";



            //修正请求页数中可能的错误
            pageid = pageid < 1 ? 1 : pageid;

            vote_list = null; //Attachments.GetVotelist(0, int.Parse(orderby), pageid, pagesize, ordertype, ref totalvote).Tables[0];


            //获取总页数
            pagecount = totalvote % pagesize == 0 ? totalvote / pagesize : totalvote / pagesize + 1;
            pagecount = pagecount == 0 ? 1 : pagecount;

            pageid = pageid > pagecount ? pagecount : pageid;

            //得到页码链接
            pagenumbers = Utils.GetPageNumbers(pageid, pagecount, string.Format("votelist.aspx{0}", string.Format("?orderby={0}&ordertype={1}", orderby, ordertype)), 8);
        }
    }
}
