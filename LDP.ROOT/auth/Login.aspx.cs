using LDP.Business;
using LDP.Data.Constants;
using LDP.Lib.Common;
using LDP.ROOT.Base;
using LDP.ROOT.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LDP.ROOT
{
    public partial class Login : LDPBase
    {
        protected void Page_Init(object sender, EventArgs e)
        {
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = UserName.Value.Trim();
            string password = Password.Value;
            
            User user = new User(userName);
            if ((user.Status & (int)UserStatus.Active) >0 && (user.Status & ((int)UserStatus.Block  + (int)UserStatus.Delete)) <= 0)
            {
                if ((user.Status & (int)UserStatus.Encryption) > 0)
                {
                    password = CryptoHelper.Encrypt(Password.Value);
                    if (user.Password== password)
                    {
                        FormsAuthentication.SetAuthCookie(user.Id.ToString(), true);
                        Response.Redirect("default.aspx");
                    }
                }           
            }
            else
            {
                ltrError.Text = "Login error";
            }

            // 1 == 1;
        }
    }
}