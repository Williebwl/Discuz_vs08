using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Discuz.Web.UI;
using System.Timers;
using System.Xml;

namespace Discuz.Web
{

    public class taohua_5000 : UserCpPage
    {
        #region
        public int totalnumber = 0;
        #endregion
        protected override void ShowPage()
        {
            //load();
            //Timer timer = new Timer(3000);
            //timer.Elapsed += new ElapsedEventHandler(theout);
            //timer.AutoReset = true;
            //timer.Start();
        }


        public void theout(object source, ElapsedEventArgs e)
        {
            IsEditor();
        }

        public void load()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds.ReadXml(Server.MapPath("~/xml/timernumber.xml"));
            dt = ds.Tables[0];
            totalnumber = Convert.ToInt32(dt.Rows[0]["text"].ToString());
        }
        private void IsEditor()
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(Server.MapPath("~/xml/timernumber.xml"));
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds.ReadXml(Server.MapPath("~/xml/timernumber.xml"));
            dt = ds.Tables[0];
            int number = Convert.ToInt32(dt.Rows[0]["text"].ToString());
            Random r = new Random();
            int num = r.Next(10, 99);
            totalnumber = number + num;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    XmlNodeList nodelist = xmldoc.SelectSingleNode("number").ChildNodes;
                    foreach (XmlNode xn in nodelist)
                    {
                        XmlElement xe = (XmlElement)xn;
                        xe.SetAttribute("text", totalnumber.ToString());
                        xmldoc.Save(Server.MapPath("~/xml/timernumber.xml"));
                        break;

                    }
                }

            }
        }
    }

}
