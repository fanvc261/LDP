using LDP.Business;
using LDP.Data.Constants;
using LDP.ROOT.Base;
using LDP.ROOT.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LDP.ROOT
{
    public partial class Default : LDPBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Literal ltr1 = new Literal();
            //ltr1.Text = "<h1>Hello Asp.Net.</h1>";
            //Literal ltr2 = new Literal();
            //ltr2.Text = "<h3>GUIDs are used in enterprise software development in C#, Java, and C++ as database keys, component identifiers, or just about anywhere else a truly unique identifier is required. GUIDs are also used to identify all interfaces and objects in COM programming.</h3>";
            //phContentRight.Controls.Add(ltr1);
            //phContentRight.Controls.Add(ltr2);

            List<Wiget> lstWiget = Wiget.GetAll();
            foreach (Wiget item in lstWiget)
            {
                if ((item.Status & (int)WigetStatus.Active) > 0)
                {
                    Literal ltrWiget = new Literal();
                    ltrWiget.Text = RenderHelper.RenderWigetCtr(item,siteSetting.SiteStatus);
                    switch (item.ContainerGuid.ToString())
                    {
                        case ContainerGuid.GuidHeader:
                            phContentHeader.Controls.Add(ltrWiget);
                            break;
                        case ContainerGuid.GuidTop:
                            phContentTop.Controls.Add(ltrWiget);
                            break;
                        case ContainerGuid.GuidLeft:
                            phContentLeft.Controls.Add(ltrWiget);
                            break;
                        case ContainerGuid.GuidRight:
                            phContentRight.Controls.Add(ltrWiget);
                            break;
                        case ContainerGuid.GuidBottom:
                            phContentBottom.Controls.Add(ltrWiget);
                            break;
                        case ContainerGuid.GuidFooter:
                            phContentFooter.Controls.Add(ltrWiget);
                            break;
                    }
                }
            }
        }
    }
}