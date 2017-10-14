using LDP.Business;
using LDP.Data.Constants;
using LDP.Lib.Common;
using LDP.ROOT.Base;
using LDP.ROOT.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LDP.ROOT
{
    public partial class Default : LDPBase
    {
        protected void Page_Init(object sender, EventArgs e)
        {
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //Literal ltr1 = new Literal();
            //ltr1.Text = "<h1>Hello Asp.Net.</h1>";
            //Literal ltr2 = new Literal();
            //ltr2.Text = "<h3>GUIDs are used in enterprise software development in C#, Java, and C++ as database keys, component identifiers, or just about anywhere else a truly unique identifier is required. GUIDs are also used to identify all interfaces and objects in COM programming.</h3>";
            //phContentRight.Controls.Add(ltr1);
            //phContentRight.Controls.Add(ltr2);
            if (!Page.IsPostBack)
            {
                List<Wiget> lstWiget = Wiget.GetByPage(PageId, (int)WigetStatus.Active);
                foreach (Wiget item in lstWiget)
                {
                    if ((item.Status & (int)WigetStatus.Active) > 0)
                    {
                        Literal ltrWiget = new Literal();
                        ltrWiget.Text = RenderHelper.RenderWigetCtr(item, siteSetting.SiteStatus);
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
                Category objCurpage = new Category(PageId);
                Literal ltrTitle = new Literal();
                StringBuilder sb = new StringBuilder();

                string siteTitle = new Setting("Site.Title").Content;
                sb.Append(RenderHelper.RenderTitlePage(siteTitle + " - " + objCurpage.Name));
                sb.Append(RenderHelper.RenderMetaPage("name", "title", siteTitle + " - " + objCurpage.MetaTitle));
                sb.Append(RenderHelper.RenderMetaPage("name", "keyword", siteTitle + " - " + objCurpage.MetaKeywords));
                sb.Append(RenderHelper.RenderMetaPage("name", "description", siteTitle + " - " + objCurpage.MetaDescription));

                sb.Append(RenderHelper.RenderMetaPage("property", "og:title", siteTitle + " - " + objCurpage.MetaTitle));
                sb.Append(RenderHelper.RenderMetaPage("property", "og:type", PageId == 1 ? "website" : "article"));
                sb.Append(RenderHelper.RenderMetaPage("property", "og:description", siteTitle + " - " + objCurpage.MetaDescription));
                sb.Append(RenderHelper.RenderMetaPage("property", "og:image", SiteUtils.GetApplicationParth() + "/data/img/logo_thumbnail.jpg"));
                sb.Append(RenderHelper.RenderMetaPage("property", "og:url", SiteUtils.GetApplicationParth()));

                sb.Append(RenderHelper.RenderMetaPage("name", "twitter:card", "summary"));
                sb.Append(RenderHelper.RenderMetaPage("name", "twitter:url", HttpContext.Current.Request.RawUrl));
                sb.Append(RenderHelper.RenderMetaPage("name", "twitter:title", siteTitle + " - " + objCurpage.MetaTitle));
                sb.Append(RenderHelper.RenderMetaPage("name", "twitter:image", SiteUtils.GetApplicationParth() + "/data/img/logo_thumbnail.jpg"));
                sb.Append(RenderHelper.RenderMetaPage("name", "twitter:description", siteTitle + " - " + objCurpage.MetaDescription));

                sb.Append(RenderHelper.RenderMetaPage("itemprop", "name", siteTitle + " - " + objCurpage.MetaTitle));
                sb.Append(RenderHelper.RenderMetaPage("itemprop", "description", siteTitle + " - " + objCurpage.MetaDescription));

                sb.Append(RenderHelper.RenderRel("canonical", HttpContext.Current.Request.RawUrl));
                ltrTitle.Text = sb.ToString();
                phHeader.Controls.Add(ltrTitle);

                Literal ltrHeader = new Literal();
                ltrHeader.Text = HttpUtility.HtmlDecode(new Setting("Embed.Header").Content);
                phHeader.Controls.Add(ltrHeader);

                Literal ltrBody = new Literal();
                ltrBody.Text = HttpUtility.HtmlDecode(new Setting("Embed.Body").Content);
                phBody.Controls.Add(ltrBody);


                Literal ltrFooter = new Literal();
                ltrFooter.Text = HttpUtility.HtmlDecode(new Setting("Embed.Footer").Content);
                phFooter.Controls.Add(ltrFooter);

                Literal ltrAdminEdit = new Literal();
                ltrFooter.Text = RenderHelper.RenderInfoAdminEdit(siteSetting.SiteStatus, siteSetting.IsAuthenticated);
                phContentAdmin.Controls.Add(ltrAdminEdit);
            }
        }
    }
}