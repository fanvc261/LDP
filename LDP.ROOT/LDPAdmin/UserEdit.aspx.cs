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
    public partial class UserEdit : LDPAdminBase
    {
        int userId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            loadQueryString();
            if (!Page.IsPostBack)
            {
                loadString();
                loadControls();
            }
        }

        private void loadString()
        {
            Page.Title = GetLocalResourceObject("Title").ToString();
        }

        private void loadQueryString()
        {
            userId = string.IsNullOrEmpty(SiteUtils.QueryString("userId")) ? 0 : Convert.ToInt32(SiteUtils.QueryString("userId"));
        }

        private void loadControls()
        {
            btnSave.Text = "Thêm mới";
            txtUserName.Text = "";
            txtPassword.Text = "";
            if (userId > 0)
            {
                User user = new User(userId);
                txtEmail.Text = user.Email;
                txtFullName.Text = user.FullName;
                txtUserName.Text = user.UserName;
                txtUserName.Enabled = false;
                if ((user.Status & (int)UserStatus.Active) > 0)
                {
                    cbActive.Checked = true;
                }
                if ((user.Status & (int)UserStatus.Block) > 0)
                {
                    cbBlock.Checked = true;
                }
                btnSave.Text = "Cập nhật";
            }
            else
            {
                btnDel.Visible = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            User user;
            int status = 0;
            if (userId > 0)
            {
                user = new User(userId);
                txtUserName.Enabled = false;
            }
            else
            {
                user = new User();
                status = status | (int)UserStatus.Encryption;
                user.UserGuid = Guid.NewGuid();
                user.Password = CryptoHelper.CalculateMD5Hash(txtPassword.Text);
                user.UserName = txtUserName.Text;
                user.Option = 0;
            }
            user.Email = txtEmail.Text;
            user.FullName = txtFullName.Text;
            if (cbActive.Checked)
            {
                status = status | (int)UserStatus.Active;
            }
            if (cbBlock.Checked)
            {
                status = status | (int)UserStatus.Block;
            }

            if (txtPassword.Text != "")
            {
                status = status | (int)UserStatus.Encryption;
                user.Password = CryptoHelper.CalculateMD5Hash(txtPassword.Text);
            }
            user.Status = status;
            
            user.Save();
            Response.Redirect("/LDPAdmin/UserList.aspx");
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            if (userId > 0)
            {
                LDP.Business.User.Delete(userId);
                Response.Redirect("/LDPAdmin/UserList.aspx");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

            Response.Redirect("/LDPAdmin/UserList.aspx");
        }
    }
}