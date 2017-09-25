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
    public class LDPBase : System.Web.UI.Page
    {
        string LangCode = "EN";
        public int PageId { get; set; }
        public SiteSettings siteSetting { get; set; }
        public LDPBase()
        {
            Init += LDPBase_Init;
        }

        void LDPBase_Init(object sender, EventArgs e)
        {
            siteSetting = SiteSettings.GetCurrentSiteSettings();
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
            PageId = 1;
            string virtualPath = RouteData.Route != null ? ((System.Web.Routing.PageRouteHandler)RouteData.RouteHandler).VirtualPath : "";
            string spage = WebUtils.LoadParamFromURL("pageid", virtualPath);
            //if (spage != null)
            PageId = string.IsNullOrEmpty(spage) ? 1 : Convert.ToInt32(spage);
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
