using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Linq;
using LDP.ROOT.Helper;
using LDP.ROOT.Models;
using System.IO;
using System.Web.Script.Serialization;
using System.Web.Script.Services;

namespace LDP.ROOT
{
    /// <summary>
    /// Summary description for DataService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public partial class ImageService : System.Web.Services.WebService
    {
        private const string contentFolderRoot = "~/data/";
        private const string prettyName = "Images/";
        private static readonly string[] foldersToCopy = new[] { "~/data/editor/" };
        private const string DefaultFilter = "*.png,*.gif,*.jpg,*.jpeg";

        private const int ThumbnailHeight = 80;
        private const int ThumbnailWidth = 80;

        private readonly DirectoryBrowser directoryBrowser;
        private readonly ContentInitializer contentInitializer;
        private readonly ThumbnailCreator thumbnailCreator;

        public class Image_Result
        {
            public string name { get; set; }
            public string type { get; set; }
            public long size { get; set; }

        }

        public ImageService()
        {
            directoryBrowser = new DirectoryBrowser();
            contentInitializer = new ContentInitializer(contentFolderRoot, foldersToCopy, prettyName);
            thumbnailCreator = new ThumbnailCreator();
        }

        private string ToAbsolute(string virtualPath)
        {
            return VirtualPathUtility.ToAbsolute(virtualPath);
        }

        private string CombinePaths(string basePath, string relativePath)
        {
            return VirtualPathUtility.Combine(VirtualPathUtility.AppendTrailingSlash(basePath), relativePath);
        }

        public virtual bool AuthorizeRead(string path)
        {
            return CanAccess(path);
        }

        protected virtual bool CanAccess(string path)
        {
            return path.StartsWith(ToAbsolute(ContentPath), StringComparison.OrdinalIgnoreCase);
        }

        private string NormalizePath(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return ToAbsolute(ContentPath);
            }

            return CombinePaths(ToAbsolute(ContentPath), path);
        }

        public string ContentPath
        {
            get
            {
                return contentInitializer.CreateUserFolder(HttpContext.Current.Server);
            }
        }

        [WebMethod ]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Read(string path)
        {
            path = NormalizePath(path);

            if (AuthorizeRead(path))
            {
                try
                {
                    directoryBrowser.Server = HttpContext.Current.Server;

                    var result = directoryBrowser
                        .GetContent(path, DefaultFilter)
                        .Select(f => new Image_Result
                        {
                            name = f.Name,
                            type = f.Type == EntryType.File ? "f" : "d",
                            size = f.Size
                        });

                    HttpContext.Current.Response.Write( new JavaScriptSerializer().Serialize(result.ToList()));
                }
                catch (DirectoryNotFoundException)
                {
                    throw new HttpException(404, "File Not Found");
                }
            }

            //throw new HttpException(403, "Forbidden");
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Thumbnail(string path)
        {
            path = NormalizePath(path);

            if (AuthorizeThumbnail(path))
            {
                var physicalPath = Server.MapPath(path);

                if (System.IO.File.Exists(physicalPath))
                {
                    HttpContext.Current.Response.AddFileDependency(physicalPath);

                    CreateThumbnail(physicalPath);
                }
                else
                {
                    throw new HttpException(404, "File Not Found");
                }
            }
            else
            {
                throw new HttpException(403, "Forbidden");
            }
        }

        private void CreateThumbnail(string physicalPath)
        {
            using (var fileStream = System.IO.File.OpenRead(physicalPath))
            {
                var desiredSize = new ImageSize
                {
                    Width = ThumbnailWidth,
                    Height = ThumbnailHeight
                };

                const string contentType = "image/png";

                HttpContext.Current.Response.ContentType = contentType;
                new MemoryStream(thumbnailCreator.Create(fileStream, desiredSize, contentType)).WriteTo(HttpContext.Current.Response.OutputStream);


                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();
            }
        }

        public virtual bool AuthorizeThumbnail(string path)
        {
            return CanAccess(path);
        }
    }
}
