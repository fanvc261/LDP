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
using LDP.ROOT.Models.FileBrowser;

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
       
        //private const string DefaultFilter = "*.png,*.gif,*.jpg,*.jpeg";
        private FileBrowserHelper fHelper;
        private const int ThumbnailHeight = 80;
        private const int ThumbnailWidth = 80;
        private readonly DirectoryBrowser directoryBrowser;

        public class Image_Result
        {
            public string name { get; set; }
            public string type { get; set; }
            public long size { get; set; }

        }

        public ImageService()
        {
            directoryBrowser = new DirectoryBrowser();
            fHelper = new FileBrowserHelper(true);
        } 

        [WebMethod ]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Read(string path)
        {
            path = fHelper.NormalizePath(path);

            if (fHelper.AuthorizeRead(path))
            {
                try
                {
                    directoryBrowser.Server = HttpContext.Current.Server;

                    var result = directoryBrowser
                        .GetContent(path, fHelper.DefaultFilter)
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
            path = fHelper.NormalizePath(path);

            if (fHelper.AuthorizeThumbnail(path))
            {
                var physicalPath = Server.MapPath(path);

                if (System.IO.File.Exists(physicalPath))
                {
                    HttpContext.Current.Response.AddFileDependency(physicalPath);

                    fHelper.CreateThumbnail(physicalPath,ThumbnailWidth,ThumbnailHeight);
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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Image(string path)
        {
            path = fHelper.NormalizePath(path);

            if (fHelper.AuthorizeFile(path))
            {
                var physicalPath = Server.MapPath(path);

                if (System.IO.File.Exists(physicalPath))
                {
                    const string contentType = "image/png";
                    HttpContext.Current.Response.ContentType = contentType;
                    new MemoryStream(System.IO.File.ReadAllBytes(physicalPath)).WriteTo(HttpContext.Current.Response.OutputStream);
 


                    HttpContext.Current.Response.Flush();
                    HttpContext.Current.Response.End();

                }
            }

            //throw new HttpException(403, "Forbidden");
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Create(string path,string name, string size, string type )
        {
            //FileBrowserEntry entry = new FileBrowserEntry();
            path = fHelper.NormalizePath(path);

            if (!string.IsNullOrEmpty(name) && fHelper.AuthorizeCreateDirectory(path, name))
            {
                var physicalPath = Path.Combine(Server.MapPath(path), name);

                if (!Directory.Exists(physicalPath))
                {
                    Directory.CreateDirectory(physicalPath);
                }

                

                HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(new Image_Result
                {
                    name = name,
                    type = "d",
                    size = string.IsNullOrEmpty(size) ? 0: Convert.ToInt64(size)
                }));
            }

           // throw new HttpException(403, "Forbidden");
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Destroy(string path, string name, string type)
        {
            path = fHelper.NormalizePath(path);

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(type))
            {
                path = fHelper.CombinePaths(path, name);
                if (type.ToLowerInvariant() == "f")
                {
                    fHelper.DeleteFile(path);
                }
                else
                {
                    fHelper.DeleteDirectory(path);
                }

                HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(0));
            }
            //throw new HttpException(404, "File Not Found");
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Upload(string path, HttpPostedFileBase file)
        {
            path = fHelper.NormalizePath(path);
            var fileName = Path.GetFileName(file.FileName);

            if (fHelper.AuthorizeUpload(path, file))
            {
                file.SaveAs(Path.Combine(Server.MapPath(path), fileName));

                HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(new Image_Result
                {
                    name = fileName,
                    type = "f",
                    size = file.ContentLength
                }));
            }

            //throw new HttpException(403, "Forbidden");
        }

        


        
    }
}
