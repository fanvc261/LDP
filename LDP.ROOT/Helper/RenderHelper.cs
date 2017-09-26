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
            //if ((status & (int)PageStatus.Admin) > 0)
            {
                classwiget += " wiget-md-edit";
                ctrEdit += "<div class='wiget-content-actions'>";
                ctrEdit += "<i class='material-icons wiget-content-button wiget-content-edit-inline'>filter_center_focus</i>";
                ctrEdit += "<i class='material-icons wiget-content-button wiget-content-edit'>edit</i>";
                ctrEdit += "</div>";
            }
            //else
            //    classwiget += " wiget-md-view";
            return HttpUtility.HtmlDecode("<div class='" + classwiget + "' data-id='" + wiget.Id.ToString() + "'>" + ctrEdit + "<div class='wiget-content-body'>" + wiget.Content + "</div></div>");
        }

        public static string RenderTitlePage(string title)
        {
            return "<title>" + title + "</title>";
        }

        public static string RenderRel(string type, string title)
        {
            return "<link  rel=\"" + type + "\" href=\"" + title + "\" />";
        }

        public static string RenderMetaPage( string type, string name, string title)
        {
            return "<meta " + type + "= " + name + " content=\"" + title + "\" />";
        }

    }
}
