using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

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
                HttpPostedFile postedFile = context.Request.Files["Filedata"];
                string savepath = "";
                string tempPath = "";
                tempPath = "assets/uploads";
                savepath = context.Server.MapPath(tempPath);
                string filename = postedFile.FileName;
                if (!Directory.Exists(savepath))
                    Directory.CreateDirectory(savepath);

                // resize Img
                System.Drawing.Image ImageFile = System.Drawing.Image.FromStream(postedFile.InputStream);
                int imageHeight = ImageFile.Height;
                int imageWidth = ImageFile.Width;
                string strmaxHeight = System.Configuration.ConfigurationManager.AppSettings["maxHeightImages"];
                int maxHeight = string.IsNullOrEmpty(strmaxHeight) == true? 320 : int.Parse(strmaxHeight);
                string strmaxWidth = System.Configuration.ConfigurationManager.AppSettings["maxWidthImages"];
                int maxWidth = string.IsNullOrEmpty(strmaxWidth) == true ? 480 : int.Parse(strmaxWidth);

                imageHeight = (imageHeight * maxWidth) / imageWidth;
                imageWidth = maxWidth;
                if (imageHeight > maxHeight)
                {
                    imageWidth = (imageWidth * maxHeight) / imageHeight;
                    imageHeight = maxHeight;
                }

                var fileNameGuid = Guid.NewGuid().ToString() + ".png";

                Bitmap BitmapFile = new Bitmap(ImageFile, imageWidth, imageHeight);
                BitmapFile.Save(savepath + @"\" + fileNameGuid, System.Drawing.Imaging.ImageFormat.Png);
                
                //stream.Position = 0;
                //byte[] data = new byte[stream.Length + 1];
                //stream.Read(data, 0, data.Length);
                //FileInfo fi = new FileInfo(filename);
                //string ext = fi.Extension;
                //var fileNameGuid = Guid.NewGuid().ToString() + ext;
                //postedFile.SaveAs(savepath + @"\" + fileNameGuid);

                context.Response.Write(fileNameGuid);
                context.Response.StatusCode = 200;

            }
            catch (Exception ex)
            {
                context.Response.Write("Error: " + ex.Message);
            }
        }

        private Bitmap ResizeBitmap(Bitmap b, int nWidth, int nHeight)
        {
            Bitmap result = new Bitmap(nWidth, nHeight);
            using (Graphics g = Graphics.FromImage((System.Drawing.Image)result))
                g.DrawImage(b, 0, 0, nWidth, nHeight);
            return result;
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}