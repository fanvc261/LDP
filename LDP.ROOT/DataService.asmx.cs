using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Linq;
using LDP.ROOT.Helper;
using static LDP.ROOT.AdminService;
using LDP.Business;
using LDP.Lib.Common;

namespace LDP.ROOT
{
    /// <summary>
    /// Summary description for DataService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public partial class DataService : System.Web.Services.WebService
    {
        SiteSettings siteSetting = SiteSettings.GetCurrentSiteSettings();
        DataTable provisionalTable = new DataTable();
        [WebMethod]
        public string HelloWorld() 
        {
            return "Hello World";
        }

        [WebMethod]
        public string_Result RegInfo_Save(string field1, string field2, string field3, string field4, string field5, string field6, string field7)
        {
            try
            {
                RegInfo obj = new RegInfo();
                obj.CreatedOn = DateTime.Now;
                obj.Field1 = field1.HtmlPlainText();
                obj.Field2 = field2.HtmlPlainText();
                obj.Field3 = field3.HtmlPlainText();
                obj.Field4 = field4.HtmlPlainText();
                obj.Field5 = field5.HtmlPlainText();
                obj.Field6 = field6.HtmlPlainText();
                obj.Field7 = field7.HtmlPlainText();
                return new string_Result()
                {
                    success = 1,
                    data = obj.Save() ? "1" : "0",
                    error = new WebService_Error_Result()
                    {
                        code = 1,
                        message = "success"
                    }
                };
            }
            catch (Exception e)
            {
                return new string_Result()
                {
                    success = 0,
                    data = null,
                    error = new WebService_Error_Result()
                    {
                        code = 0,
                        message = e.ToString()
                    }
                };
            }
        }

    }
}
