using LDP.Business;
using LDP.Lib.Common;
using LDP.ROOT.Base;
using LDP.ROOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LDP.ROOT.LDPAdmin
{
    public partial class pupWiget : LDPAdminBase
    {
        int wigetId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                loadQueryString();
                loadControls();
            }
        }

        private void  loadString()
        {
            Page.Title = GetLocalResourceObject("Title").ToString();
        }

        private void loadQueryString()
        {
            wigetId = string.IsNullOrEmpty(SiteUtils.QueryString("id")) ? 1 : Convert.ToInt32(SiteUtils.QueryString("id"));
        }

        private void loadControls()
        {
            Wiget obj = new Wiget(wigetId);
            if (obj.Id>0)
            {
                ltrTitle.Text = obj.Name;
                txtContent.InnerText = HttpUtility.HtmlDecode(obj.Content);
            }
        }
    }
}