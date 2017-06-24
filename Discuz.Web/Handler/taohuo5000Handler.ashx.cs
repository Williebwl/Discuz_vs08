using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml;

namespace Discuz.Web.Handler
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class taohuo5000Handler : IHttpHandler
    {
        HttpRequest Request;
        HttpResponse Response;
        HttpServerUtility Server;
        private int totalnumber = 0;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Request = context.Request;
            Response = context.Response;
            Server = context.Server;
            IsEditor();
        }

        private void IsEditor()
        {
            try
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
                totalnumber = (number + num);
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
                Response.Write("{\"result\":\"1\",\"num\":\"" + totalnumber + "\"}");
            }
            catch (Exception ex)
            {
                Response.Write("{\"result\":\"0\"}");
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
