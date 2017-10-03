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
    public static class RenderHelper
    {
        public static string RenderWigetCtr(Wiget wiget, int status)
        {
            string classwiget = "wiget-control " + wiget.ClassBody;
            string ctrEdit = "";
            if ((status & (int)PageStatus.Admin) > 0)
            {
                classwiget += " wiget-md-edit";
                ctrEdit += "<div class='wiget-content-actions'>";
                ctrEdit += "<i class='material-icons wiget-content-button wiget-content-edit-inline'>filter_center_focus</i>";
                ctrEdit += "<i class='material-icons wiget-content-button wiget-content-edit'>edit</i>";
                ctrEdit += "</div>";
            }
            else
                classwiget += " wiget-md-view";
            return HttpUtility.HtmlDecode("<div class='" + classwiget + "' data-id='" + wiget.Id.ToString() + "'>" + ctrEdit + "<div class='wiget-content-body'>" + wiget.Content + "</div></div>" + Environment.NewLine);
        }

        public static string RenderInfoAdminEdit(int status, bool isAuth)
        {
            string ctrEdit = "";
            string strChecked = "";
            if ((status & (int)PageStatus.Admin) > 0)
            {
                ctrEdit = "<div class='modal fade bgmodal' id='bg-modal-admin'></div>";
                ctrEdit += "<div class='wiget-content-popup'>";
                ctrEdit += "<iframe id='fr-admin-popup' src='/LDPAdmin/Popup/pupWiget.aspx?id=1'></iframe>";
                ctrEdit += "</div>";
                strChecked = "checked='checked'";
            }
            if (isAuth)
            {
                ctrEdit += "<div class='fixed-plugin admin-mode' id='setting-admin-mode'><div class='togglebutton'><label><span class='title-mode'>Mode</span><input id='chkAdminMode' " + strChecked + " type ='checkbox'>";
                ctrEdit += "</label></div></div>";
            }
            return HttpUtility.HtmlDecode(ctrEdit + Environment.NewLine);
        }

        public static string RenderTitlePage(string title)
        {
            return "<title>" + title + "</title>" + Environment.NewLine;
        }

        public static string RenderRel(string type, string title)
        {
            return "<link  rel=\"" + type + "\" href=\"" + title + "\" />" + Environment.NewLine;
        }

        public static string RenderMetaPage( string type, string name, string title)
        {
            return "<meta " + type + "= " + name + " content=\"" + title + "\" />" + Environment.NewLine;
        }

    }
}
