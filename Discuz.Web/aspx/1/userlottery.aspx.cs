using Discuz.Common.Generic;
using Discuz.Entity;
using Discuz.Forum;
using Discuz.Common;
using Discuz.Plugin.Space;
using Discuz.Plugin.Album;
using Discuz.Plugin.Mall;
using System.Data;
using System.Data.SqlClient;
using Discuz.Web.UI;
using System;

namespace Discuz.Web
{
    /// <summary>
    /// 标签列表页
    /// </summary>
    /// 


    public class userlottery : UserCpPage
    {
        #region 页面变量
        /// <summary>
        /// 用户列表
        /// </summary>
        public DataTable userlotterlist = new DataTable();

        /// <summary>
        /// 实时参与抽奖用户列表
        /// </summary>
        public DataTable userrealtimelist = new DataTable();
        /// <summary>
        /// 当前页码
        /// </summary>
        public int pageid = DNTRequest.GetInt("page", 1);
        /// <summary>
        /// 总用户数
        /// </summary>
        public int totalusers;
        /// <summary>
        /// 分页页数
        /// </summary>
        public int pagecount;
        /// <summary>
        /// 分页页码链接
        /// </summary>
        public string pagenumbers;

        /// <summary>
        /// 
        /// </summary>

        public int numberipad = 0;


        public string strmsg = string.Empty;
        #endregion


        protected override void ShowPage()
        {
            int total = 0;
            int refresult = 0;
            userrealtimelist = Users.GetuserRealtimeList();
            #region
            //Users.GetUserLotteryList(1, 1, ref total);
            //totalusers = total;
            ////获取总页数
            //pagecount = totalusers % 30 == 0 ? totalusers / 30 : totalusers / 10 + 1;
            //pagecount = pagecount == 0 ? 1 : pagecount;

            ////修正请求页数中可能的错误
            //pageid = pageid < 1 ? 1 : pageid;
            //pageid = pageid > pagecount ? pagecount : pageid;
            ////获取当前页主题列表
            ////得到页码链接
            //pagenumbers = Utils.GetPageNumbers(pageid, pagecount, "userlottery.aspx", 6);

            #endregion
            userlotterlist = Users.GetUserLotteryList(30, 1, ref total);
            if (userlotterlist.Rows.Count > 0) {
                strmsg = "存在数据";
            }
            numberipad = total;

            if (DNTRequest.IsPost())
            {
                if (!IsLogin()) return; //判断是否登录
                DateTime begin = DateTime.Parse(Discuz.Common.ConfigOperator.ConfigReadValue("starttime"));
                DateTime end = DateTime.Parse(Discuz.Common.ConfigOperator.ConfigReadValue("endtime"));
                if (DateTime.Now.CompareTo(begin) == 1 && (DateTime.Now.CompareTo(end) == -1))
                {
                    string ticketnumber = DNTRequest.GetString("number").Trim();
                    //进行参数过滤
                    if (!Utils.StrIsNullOrEmpty(ticketnumber))
                    {
                        Users.submitlotteryinfo(userid, ticketnumber, ref refresult);
                        if (refresult == 0)
                        {
                            AddErrLine("不能重复参与抽奖");
                            return;
                        }
                        else if (refresult == 1)
                        {
                            SetUrl("userlottery.aspx");
                            SetMetaRefresh();
                            SetShowBackLink(true);
                            AddMsgLine("参与抽奖成功");
                        }
                        else if (refresult == 3)
                        {
                            AddErrLine("输入券号不存在");
                        }
                        else
                        {
                            AddErrLine("参与抽奖失败");
                            return;
                        }
                    }
                    else
                    {
                        AddErrLine("请输入抽奖券号");
                        return;
                    }
                }
                else
                {
                    AddErrLine("不在活动时间内");
                    return;
                }
            }

        }

    }
}
