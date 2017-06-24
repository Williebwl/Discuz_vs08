using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

using Discuz.Forum;
using Discuz.Common;
using Discuz.Config;
using Discuz.Plugin.VerifyImage;
using Discuz.Entity;

namespace Discuz.Web.UI
{
    /// <summary>
    /// 验证码图片页面类
    /// </summary>
    public class VerifyImagePage : System.Web.UI.Page
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="e"></param>
        override protected void OnInit(EventArgs e)
        {
            base.OnInit(e);

            GeneralConfigInfo config = GeneralConfigs.GetConfig();
            string bgcolor = DNTRequest.GetQueryString("bgcolor").Trim();
            int textcolor = DNTRequest.GetQueryInt("textcolor", 1);
            string[] bgcolorArray = bgcolor.Split(',');

            Color bg = Color.White;
            if (bgcolorArray.Length == 1 && bgcolor != string.Empty)
                bg = Utils.ToColor(bgcolor);
            else if (bgcolorArray.Length == 3 && Utils.IsNumericArray(bgcolorArray))
                bg = Color.FromArgb(Utils.StrToInt(bgcolorArray[0], 255), Utils.StrToInt(bgcolorArray[1], 255), Utils.StrToInt(bgcolorArray[2], 255));

            CookiesHelper.FailNoDomainCoolie("CheckCode");

            OnlineUserInfo oui = OnlineUsers.UpdateInfo(config.Passwordkey, config.Onlinetimeout);
            string checkCode = oui.Verifycode;
            VerifyImageInfo verifyimg = VerifyImageProvider.GetInstance(config.VerifyImageAssemly).GenerateImage(checkCode, 120, 60, bg, textcolor);
            //用于验证 
            CookiesHelper.AddNoDomainCoolie("CheckCode", checkCode, 1);
            Bitmap image = verifyimg.Image;

            System.Web.HttpContext.Current.Response.ContentType = verifyimg.ContentType;
            image.Save(this.Response.OutputStream, verifyimg.ImageFormat);
        }
    }
}
