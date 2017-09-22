using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using log4net;
using LDP.Business;
using System.Web.Compilation;
using System.Web.UI;

namespace LDP.Web.Routing
{
    public class RouteRegistrar
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(RouteRegistrar));

        public static void RegisterRoutes(RouteCollection routes)
        {
            try
            {
                foreach (Category item in Category.GetAll())
                {
                    //RouteTable.Routes.MapPageRoute("Category" + item.Id, item.SeName, "~/Default.aspx?pageid="+ item.Id);
                    // RouteTable.Routes.MapPageRoute("Category" + item.Id, "{sename}", "~/Default.aspx");
                    routes.Add("Category" + item.Id, new Route("{sename}", new CustomRouteHandler("~/Default.aspx", item.Id)));
                }


            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

        }
    }

    public class CustomRouteHandler : IRouteHandler
    {
        public CustomRouteHandler(string virtualPath)
        {
            this.VirtualPath = virtualPath;
        }

        public CustomRouteHandler(string virtualPath, int pageId)
        {
            this.VirtualPath = virtualPath;
            this.PageId = pageId;
        }

        public string VirtualPath { get; private set; }
        public int PageId { get; private set; }

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            string productName = requestContext.RouteData.Values["sename"] as string;
            requestContext.HttpContext.Items["pageid"] = PageId;
            var page = BuildManager.CreateInstanceFromVirtualPath(VirtualPath, typeof(Page)) as IHttpHandler;
            return page;
        }

    }
}