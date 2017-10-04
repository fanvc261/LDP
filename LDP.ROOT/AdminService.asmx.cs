using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Linq;
using LDP.ROOT.Helper;
using LDP.Business;
using System.Web.Security;

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

        public class UserList_Result
        {
            public int success { get; set; }
            public List<User> data { get; set; }
            public WebService_Error_Result error { get; set; }
        }


        public class User_Result
        {
            public int success { get; set; }
            public User data { get; set; }
            public WebService_Error_Result error { get; set; }
        }

        public class Category_Result
        {
            public int success { get; set; }
            public Category data { get; set; }
            public WebService_Error_Result error { get; set; }
        }

        public class Setting_Result
        {
            public int success { get; set; }
            public Setting data { get; set; }
            public WebService_Error_Result error { get; set; }
        }

        /////////////////////////////////////////////////  Wiget   /////////////////////////////////////

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
        public string_Result Wiget_Update(int id, string name, int pageId, int rank, int status, int option, string classBody, string containerGuid, string content)
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

        [WebMethod]
        public string_Result Wiget_UpdateContent(int id, string content)
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
                    
                }

                if (obj.Id<=0)
                {
                    return new string_Result()
                    {
                        success = 0,
                        data = null,
                        error = new WebService_Error_Result()
                        {
                            code = 0,
                            message = "No data"
                        }
                    };
                }
                obj.Content = content;
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


        [WebMethod]
        public string_Result Wiget_DeleteById(int id)
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

                return new string_Result()
                {
                    success = 1,
                    data = Wiget.Delete(id) ? "1" : "0",
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

        /////////////////////////////////////////////////  Category   /////////////////////////////////////

        [WebMethod]
        public Category_Result Category_GetById(int id)
        {
            try
            {
                if (!CheckAuthorize())
                {
                    return new Category_Result()
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
                return new Category_Result()
                {
                    success = 1,
                    data = new Category(id),
                    error = new WebService_Error_Result()
                    {
                        code = 1,
                        message = "success"
                    }
                };
            }
            catch (Exception e)
            {
                return new Category_Result()
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
        public string_Result Category_Update(int id, string name, string seName, string metaTitle, string metaKeywords, string metaDescription)
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
                Category obj;
                if (id > 0)
                {
                    obj = new Category(id);
                }
                else
                {
                    obj = new Category();
                    obj.CategoryGuid = Guid.NewGuid();
                    obj.Status = 1;
                    obj.Option = 0;
                }
                if (obj.Id <= 0)
                {
                    return new string_Result()
                    {
                        success = 0,
                        data = null,
                        error = new WebService_Error_Result()
                        {
                            code = 0,
                            message = "No Data"
                        }
                    };
                }
                obj.Name = name;
                //obj.ClassBody = "";
                //obj.ClassMenu = "";
                //obj.Icon = "";
                //obj.KeyMenu = "";
                //obj.Rank = rank;
                obj.MetaDescription = metaDescription;
                obj.MetaKeywords = metaKeywords;
                obj.MetaTitle = metaTitle;
                obj.SeName = seName;

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


        /////////////////////////////////////////////////  Setting   /////////////////////////////////////

        [WebMethod]
        public Setting_Result Setting_GetEmberById(int id)
        {
            try
            {
                if (!CheckAuthorize())
                {
                    return new Setting_Result()
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
                string settingkey = "";
                switch (id)
                {
                    case 1:
                        settingkey = "Site.Title";
                        break;
                    case 2:
                        settingkey = "Embed.Header";
                        break;
                    case 3:
                        settingkey = "Embed.Body";
                        break;
                    case 4:
                        settingkey = "Embed.Footer";
                        break;

                }

                return new Setting_Result()
                {
                    success = 1,
                    data = new Setting(settingkey),
                    error = new WebService_Error_Result()
                    {
                        code = 1,
                        message = "success"
                    }
                };
            }
            catch (Exception e)
            {
                return new Setting_Result()
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
        public string_Result Setting_UpdateEmbed(int id, string content)
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
                Setting obj;

                string settingkey = "";
                switch (id)
                {
                    case 1:
                        settingkey = "Site.Title";
                        break;
                    case 2:
                        settingkey = "Embed.Header";
                        break;
                    case 3:
                        settingkey = "Embed.Body";
                        break;
                    case 4:
                        settingkey = "Embed.Footer";
                        break;

                }

                obj = new Setting(settingkey);
                if (obj.Id <= 0)
                {
                    obj.Name = settingkey;
                    obj.Option = 0;
                    obj.SettingGuid = Guid.NewGuid();
                }
                
                obj.Content = content;
                

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


        /////////////////////////////////////////////////  User   /////////////////////////////////////

        [WebMethod]
        public UserList_Result User_GetList()
        {
            try
            {
                if (!CheckAuthorize())
                {
                    return new UserList_Result()
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
                return new UserList_Result()
                {
                    success = 1,
                    data = LDP.Business.User.GetAll(),
                    error = new WebService_Error_Result()
                    {
                        code = 1,
                        message = "success"
                    }
                };
            }
            catch (Exception e)
            {
                return new UserList_Result()
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
        public User_Result User_GetById(int id)
        {
            try
            {
                if (!CheckAuthorize())
                {
                    return new User_Result()
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
                return new User_Result()
                {
                    success = 1,
                    data = new User(id),
                    error = new WebService_Error_Result()
                    {
                        code = 1,
                        message = "success"
                    }
                };
            }
            catch (Exception e)
            {
                return new User_Result()
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
        public string_Result User_UpdateMode(int mode)
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
                siteSetting.CurrentUser.Option = mode;
                return new string_Result()
                {
                    success = 1,
                    data = siteSetting.CurrentUser.Save().ToString(),
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

        [WebMethod]
        public string_Result User_Logout()
        {
            try
            {
                FormsAuthentication.SignOut();
                return new string_Result()
                {
                    success = 1,
                    data = true.ToString(),
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

        /////////////////////////////////////////////////  ***   /////////////////////////////////////
        private bool CheckAuthorize()
        {
            return true;
            return siteSetting.IsAuthenticated;
        }
    }
}
