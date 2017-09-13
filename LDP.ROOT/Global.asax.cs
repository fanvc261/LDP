using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
namespace LDP.ROOT
{
    public class Global : System.Web.HttpApplication
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Global));

        private static bool debugLog = log.IsDebugEnabled;
        protected void Application_Start(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
            log.Info("App Start");

        }

        protected void Session_Start(object sender, EventArgs e)
        { 
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
           
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }


        protected void Application_Error(Object sender, EventArgs e)
        {
            bool errorObtained = false;
            Exception ex = null;

            try
            {
                Exception rawException = Server.GetLastError();
                if (rawException != null)
                {
                    errorObtained = true;
                    if (rawException.InnerException != null)
                    {
                        ex = rawException.InnerException;
                    }
                    else
                    {
                        ex = rawException;
                    }
                }
            }
            catch { }

            string exceptionUrl = string.Empty;
            string exceptionIpAddress = string.Empty;
            string exceptionUserAgent = string.Empty;
            string exceptionReferrer = "none";

            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Request != null)
                {
                    exceptionUrl = HttpContext.Current.Request.RawUrl;
                    //exceptionIpAddress = SiteUtils.GetIP4Address();
                    if (HttpContext.Current.Request.UrlReferrer != null)
                    {
                        exceptionReferrer = HttpContext.Current.Request.UrlReferrer.ToString();
                    }

                    if (HttpContext.Current.Request.UserAgent != null)
                    {
                        exceptionUserAgent = HttpContext.Current.Request.UserAgent;
                    }

                }

            }

            if (errorObtained)
            {


                if (ex is UnauthorizedAccessException)
                {
                    // swallow this for medium trust?
                    log.Error(" Referrer(" + exceptionReferrer + ")", ex);
                    return;
                }

                if (ex is HttpException)
                {
                    exceptionIpAddress = "IP";

                    if (log4net.ThreadContext.Properties["ip"] == null)
                    {
                        log4net.ThreadContext.Properties["ip"] = exceptionIpAddress;
                    }

                    log.Error(exceptionIpAddress + " " + exceptionUrl + " Referrer(" + exceptionReferrer + ") useragent " + exceptionUserAgent, ex);
                    return;

                }

                if (ex.Message == "File does not exist.")
                {

                    log.Error(" Referrer(" + exceptionReferrer + ") useragent " + exceptionUserAgent, ex);
                    return;
                }



                log.Error(" Referrer(" + exceptionReferrer + ") useragent " + exceptionUserAgent, ex);

                if (ex is System.Security.Cryptography.CryptographicException)
                {
                    // hopefully this is a fix for 
                    //http://visualstudiomagazine.com/articles/2010/09/14/aspnet-security-hack.aspx
                    // at this time the exploit is not fully disclosed but seems tey use the 500 status code 
                    // so returning 404 instead may block it
                    

                }

            }

        }

        

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            log.Info("App End");
            
        }
    }
}