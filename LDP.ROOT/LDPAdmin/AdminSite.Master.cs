using LDP.Business;
using LDP.ROOT.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LDP.ROOT.LDPAdmin
{
    public partial class AdminSite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(! Page.IsPostBack)
            {
                ltrCurUser.Text = SiteSettings.GetCurrentSiteSettings().CurrentUser.UserName;
                rptPage.DataSource = Category.GetAll();
                rptPage.DataBind();
            }
        }
    }
}