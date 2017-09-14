using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using System.Web;
using System.Collections.Specialized;

namespace LDP.Lib.Common
{
    public class SiteUtils
    {
        public static string QueryString(string key)
        { 
             string result = String.Empty;
            if (HttpContext.Current != null && HttpContext.Current.Request.QueryString[key] != null)
            {
                result = HttpContext.Current.Request.QueryString[key].ToString();

            }
            return result;
        }
        public static string ServerVariables(string name)
        {
            string tmpS = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty( HttpContext.Current.Request.ServerVariables[name]))
                {
                    tmpS = HttpContext.Current.Request.ServerVariables[name].ToString();
                }
            }
            catch 
            {
                tmpS = string.Empty;
            }
            return tmpS;
        }

        public static string GetStoreHost(bool useSSL = false)
        {
            string result = "http://" + ServerVariables("HTTP_HOST");
            if (!result.EndsWith("/"))
            {
                result += "/";
            }

            if (useSSL)
            {
                result = result.Replace("http:/", "https:/");
                result = result.Replace("www.www", "www");
            }
            return result;
        }

        public static string GetApplicationParth()
        {
            string strApplicationPath= HttpContext.Current.Request.ApplicationPath;
            if (strApplicationPath == "/")
                return string.Empty;
            return strApplicationPath;
        }

        public static string GetLoginParth()
        {
            return GetApplicationParth() + "/login.aspx";
        }

        public static string GetHomeParth()
        {
            return GetApplicationParth() + "/default.aspx";
        }

        public static string GetXsltBaseUrl(string filename)
        {

            return GetApplicationParth() + "/data/XSL/" + filename;
        }

        public static string GetPhoneToken()
        {
            string result = "";
            if (!string.IsNullOrEmpty(CookieHelper.GetCookieValue("phoneToken")))
            {
                result =  CookieHelper.GetCookieValue("phoneToken") ;
            }
            else
            {
                NameValueCollection headers = HttpContext.Current.Request.Headers;
                for (int i = 0; i < headers.Count; i++)
                {
                    string key = headers.GetKey(i);
                    string value = headers.Get(i);
                    if (key == "phoneToken")
                    {
                        result = value ;
                    }

                }
            }
            return result;
        }
    }
}
