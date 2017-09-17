using LDP.Business;
using LDP.Data.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LDP.ROOT.Helper
{
    public class SiteSettings
    {
        public string LanguageCode { get; set; }
        public User CurrentUser { get; set; }
        public int SiteStatus { get; set; }
        public bool IsAuthenticated { get; set; }
        public static SiteSettings GetCurrentSiteSettings()
        {
            SiteSettings result = new SiteSettings();
            result.LanguageCode = "ENG";
            result.SiteStatus = 0;
            result.IsAuthenticated = HttpContext.Current.User.Identity.IsAuthenticated;
            User user = new User();
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                user = new User(HttpContext.Current.User.Identity.Name);
                result.SiteStatus = user.Option;// &(int)PageStatus.Admin;
            }
            result.CurrentUser = user;
            return result;
        }
    }
}
