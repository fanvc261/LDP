using LDP.Lib.Common;
using LDP.ROOT.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace LDP.ROOT.Base
{
    public class LDPAdminBase : System.Web.UI.Page
    {
        string LangCode = "EN";
        public SiteSettings siteSetting { get; set; }
        public LDPAdminBase()
        {
            Init += LDPAdminBase_Init;
        }

        void LDPAdminBase_Init(object sender, EventArgs e)
        {
            siteSetting = SiteSettings.GetCurrentSiteSettings();
            if (!isAuthorized())
            {
                Response.Redirect(SiteUtils.GetLoginParth());
            }
            else
            {
            }
        }    

        protected override void InitializeCulture()
        {
            base.InitializeCulture();
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        
        private bool isAuthorized()
        {
            if (Context.User.Identity.IsAuthenticated)
                return true;
            return false;
        }
    }
}
