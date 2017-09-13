using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Caching;
using System.Web.Hosting;
using log4net;
using LDP.Lib.Caching;

namespace LDP.Lib.Common
{
    public static class CacheHelper
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(CacheHelper));
        private static bool debugLog = log.IsDebugEnabled;

       
        public static void SetClientCaching(HttpContext context, DateTime lastModified)
        {
            if (context == null) return;

            context.Response.Cache.SetETag(lastModified.Ticks.ToString());
            context.Response.Cache.SetLastModified(lastModified);
            context.Response.Cache.SetCacheability(HttpCacheability.Public);
            context.Response.Cache.SetMaxAge(new TimeSpan(7, 0, 0, 0));
            context.Response.Cache.SetSlidingExpiration(true);
        }


        public static void SetFileCaching(HttpContext context, string fileName)
        {
            if (fileName == null) return;
            if (context == null) return;
            if (fileName.Length == 0) return;

            context.Response.AddFileDependency(fileName);
            context.Response.Cache.SetETagFromFileDependencies();
            context.Response.Cache.SetLastModifiedFromFileDependencies();
            context.Response.Cache.SetCacheability(HttpCacheability.Public);
            context.Response.Cache.SetMaxAge(new TimeSpan(7, 0, 0, 0));
            context.Response.Cache.SetSlidingExpiration(true);
        }


        #region cache dependency files

        public static string GetPathToCacheDependencyFile(string cacheKey)
        {
            EnsureDirectory(HostingEnvironment.MapPath("~/Data/systemfiles/"));

            return HostingEnvironment.MapPath(
                "~/Data/systemfiles/" + cacheKey + "_cachedependency.config");
        }

        private static void EnsureDirectory(string directoryPath)
        {
            if (string.IsNullOrEmpty(directoryPath)) return;

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        public static void EnsureCacheFile(string pathToCacheFile)
        {
            if (pathToCacheFile == null) return;

            if (!File.Exists(pathToCacheFile))
            {
                TouchCacheFile(pathToCacheFile);
            }
        }

        

        public static void ResetThemeCache()
        {
            if (ConfigHelper.GetBoolProperty("UseCacheDependencyFiles", false))
            {
                string pathToFile = GetPathToThemeCacheDependencyFile();
                if (pathToFile != null)
                {
                    TouchCacheFile(pathToFile);
                }
            }
        }


        public static string GetPathToThemeCacheDependencyFile()
        {
            if (HttpContext.Current == null) return null;

            
            string cacheKey = "theme_LDP";

            string path = GetPathToCacheDependencyFile(cacheKey);

            if (!File.Exists(path)) { TouchCacheFile(path); }

            return path;
        }

        public static void TouchCacheFile(String pathToCacheFile)
        {
            if (pathToCacheFile == null) return;

            try
            {
                if (File.Exists(pathToCacheFile))
                {
                    File.SetLastWriteTimeUtc(pathToCacheFile, DateTime.UtcNow);
                }
                else
                {
                    File.CreateText(pathToCacheFile).Close();
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                log.Error(ex);
            }
        }

        #endregion

      

        public static string GetPathToWebConfigFile()
        {
            return System.Web.Hosting.HostingEnvironment.MapPath("~/Web.config");
        }

    }
}
