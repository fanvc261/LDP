using LDP.Lib.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace LDP.ROOT.Models
{
    public  class XMLModel
    {
        public  Dictionary<string,string> GetContainers()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
              string pathOrUrlToFile = SiteUtils.GetXmlDataUrl("container.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(pathOrUrlToFile));
            foreach (XmlNode item in doc.DocumentElement.ChildNodes)
            {
                result.Add(item.Attributes["id"].Value, item.InnerText.Trim());
            } 
            return result;
        }
    }
}