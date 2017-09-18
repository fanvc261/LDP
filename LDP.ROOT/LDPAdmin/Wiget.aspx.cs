using LDP.Business;
using LDP.ROOT.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LDP.ROOT.LDPAdmin
{
    public partial class WigetPage : LDPAdminBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                rptWiget.DataSource = Wiget.GetAll();
                rptWiget.DataBind();
            }
        }

        private void  loadString()
        {
            Page.Title = GetLocalResourceObject("Title").ToString();
        }
    }
}