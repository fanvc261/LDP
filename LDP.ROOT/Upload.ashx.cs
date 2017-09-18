using LDP.ROOT.Models.FileBrowser;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using static LDP.ROOT.ImageService;

namespace LDP.ROOT
{
    /// <summary>
    /// Summary description for Upload
    /// </summary>
    public class Upload : IHttpHandler
    {


        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;
            try
            {
                HttpPostedFile file = context.Request.Files["file"];
                string path = context.Request["path"];
                path = new FileBrowserHelper(false).NormalizePath(path);
                var fileName = Path.GetFileName(file.FileName);


                file.SaveAs(Path.Combine(context.Server.MapPath(path), fileName));

                HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(new Image_Result
                {
                    name = fileName,
                    type = "f",
                    size = file.ContentLength
                }));

            }
            catch (Exception ex)
            {
                context.Response.Write("Error: " + ex.Message);
            }
        }

        //private Bitmap ResizeBitmap(Bitmap b, int nWidth, int nHeight)
        //{
        //    Bitmap result = new Bitmap(nWidth, nHeight);
        //    using (Graphics g = Graphics.FromImage((System.Drawing.Image)result))
        //        g.DrawImage(b, 0, 0, nWidth, nHeight);
        //    return result;
        //}


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}