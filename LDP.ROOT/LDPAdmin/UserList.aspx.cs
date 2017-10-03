using LDP.Business;
using LDP.Data.Constants;
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
    public partial class UserList : LDPAdminBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                loadString();
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
            
        }

        private void loadControls()
        {
           
        }
    }
}