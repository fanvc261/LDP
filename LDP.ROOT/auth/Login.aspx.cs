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
            string userName = UserName.Text.Trim();
            string password = Password.Text;

            User user = new User(userName);
            if ((user.Status & (int)UserStatus.Active) > 0 && (user.Status & ((int)UserStatus.Block + (int)UserStatus.Delete)) <= 0)
            {
                if ((user.Status & (int)UserStatus.Encryption) > 0)
                {
                    password = CryptoHelper.CalculateMD5Hash(Password.Text);
                }
                if (user.Password == password)
                {
                    FormsAuthentication.SetAuthCookie(user.Id.ToString(), true);
                    Response.Redirect("/");
                }

            }
            ltrError.Text = "Tài khoản không chính xác. Vui lòng kiểm tra lại.";

            // 1 == 1;
        }
    }
}