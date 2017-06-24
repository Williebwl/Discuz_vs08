using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Discuz.Common
{
    public class ConfigOperator
    {
        public ConfigOperator() { }

        public static string ConfigReadValue(string key)
        {
            string svalue = string.Empty;
            try
            {
                svalue = System.Configuration.ConfigurationSettings.AppSettings[key];
            }
            catch (Exception ex)
            {
                throw new ArgumentException("没有找到的配置节" + ex.ToString());
            }
            return svalue;
        }

        public static void ConfigWriteValue(string key, string strValue, XmlDocument doc, string sXmlPath)
        {
            string XPath = "/configuration/appSettings/add[@key='?']";
            XmlNode addKey = doc.SelectSingleNode((XPath.Replace("?", key)));
            if (addKey == null)
            {
                throw new ArgumentException("没有找到的配置节");
            }
            addKey.Attributes["value"].InnerText = strValue;
            doc.Save(sXmlPath);
        }
    }
}
