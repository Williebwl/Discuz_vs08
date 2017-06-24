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
    public class taohua_xianzi : PageBase
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
        public int pagesize = 20;
        /// <summary>
        /// 分页页码链接
        /// </summary>
        public string pagenumbers;
        /// <summary>
        /// 美图ID
        /// </summary>
        public int aid = 0;
        public string posttitle = string.Empty;
        /// <summary>
        /// 会员ID
        /// </summary>
        public int uid = 0;
        public string orderby = string.Empty;
        public string ordertype = string.Empty;
        #endregion
        protected override void ShowPage()
        {
            pagetitle = "选桃花仙子享迪拜游";
            orderby = DNTRequest.GetString("orderby").Trim();
            if (ValidatorHelper.IsInt(DNTRequest.GetString("txt_aid")))
            {
                aid = DNTRequest.GetInt("txt_aid", 0);
            }
            else
            {
                posttitle = DNTRequest.GetString("txt_aid");
                if (posttitle.Equals("请输入选手号/姓名"))
                {
                    posttitle = string.Empty;
                }
            }

            //进行参数过滤
            if (!Utils.InArray(orderby, "0,1,2"))
                orderby = "1";

            ordertype = DNTRequest.GetString("ordertype").Trim();
            //进行参数过滤      
            if (!ordertype.Equals("desc") && !ordertype.Equals("asc"))
                ordertype = "desc";



            //修正请求页数中可能的错误
            pageid = pageid < 1 ? 1 : pageid;

            vote_list = Attachments.GetVotelist(aid, posttitle, int.Parse(orderby), pageid, pagesize, ordertype, ref totalvote).Tables[0];


            //获取总页数
            pagecount = totalvote % pagesize == 0 ? totalvote / pagesize : totalvote / pagesize + 1;
            pagecount = pagecount == 0 ? 1 : pagecount;

            pageid = pageid > pagecount ? pagecount : pageid;

            //得到页码链接
            pagenumbers = Utils.GetPageNumbers(pageid, pagecount, string.Format("taohua_xianzi.aspx{0}", string.Format("?orderby={0}&ordertype={1}", orderby, ordertype)), 8);
        }
    }
}
