using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Linq;
using LDP.ROOT.Helper;
using LDP.Business;

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
    public partial class AdminService : System.Web.Services.WebService
    {
        SiteSettings siteSetting = SiteSettings.GetCurrentSiteSettings();
        DataTable provisionalTable = new DataTable();

        public class WebService_Error_Result
        {
            public int code { get; set; }
            public string message { get; set; }
        }

        public class string_Result
        {
            public int success { get; set; }
            public string data { get; set; }
            public WebService_Error_Result error { get; set; }
        }


        public class WigetList_Result
        {
            public int success { get; set; }
            public List<Wiget> data { get; set; }
            public WebService_Error_Result error { get; set; }
        }


        public class Wiget_Result
        {
            public int success { get; set; }
            public Wiget data { get; set; }
            public WebService_Error_Result error { get; set; }
        }

        [WebMethod]
        public WigetList_Result Wiget_GetList() 
        {
            try
            {
                if (!CheckAuthorize())
                { 
                    return new WigetList_Result()
                    {
                        success = 0,
                        data = null,
                        error = new WebService_Error_Result()
                        {
                            code = 0,
                            message = "No Login"
                        }
                    };
                }
                return new WigetList_Result()
                {
                    success = 1,
                    data = Wiget.GetAll(),
                    error = new WebService_Error_Result()
                    {
                        code = 1,
                        message = "success"
                    }
                };
            }
            catch (Exception e)
            {
                return new WigetList_Result()
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

        [WebMethod]
        public Wiget_Result Wiget_GetById(int id)
        {
            try
            {
                if (!CheckAuthorize())
                {
                    return new Wiget_Result()
                    {
                        success = 0,
                        data = null,
                        error = new WebService_Error_Result()
                        {
                            code = 0,
                            message = "No Login"
                        }
                    };
                }
                return new Wiget_Result()
                {
                    success = 1,
                    data = new Wiget(id),
                    error = new WebService_Error_Result()
                    {
                        code = 1,
                        message = "success"
                    }
                };
            }
            catch (Exception e)
            {
                return new Wiget_Result()
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

        [WebMethod]
        public string_Result Wiget_Update(int id, string name, int pageId,int rank, int status, int option,string classBody,string containerGuid, string content)
        {
            try
            {
                if (!CheckAuthorize())
                {
                    return new string_Result()
                    {
                        success = 0,
                        data = null,
                        error = new WebService_Error_Result()
                        {
                            code = 0,
                            message = "No Login"
                        }
                    };
                }
                Wiget obj;
                if (id > 0)
                {
                    obj = new Wiget(id);
                }
                else
                {
                    obj = new Wiget();
                    obj.PageId = pageId;
                    obj.WigetGuid = Guid.NewGuid();
                }
                obj.Name = name;
                obj.ClassBody = classBody;
                obj.ContainerGuid = new Guid(containerGuid); 
                obj.Content = content;
                obj.Option = option;              
                obj.Rank = rank;
                obj.Status = status;
                obj.Save();
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
        private bool CheckAuthorize()
        {
            return true;
            return siteSetting.IsAuthenticated;
        }
    }
}
