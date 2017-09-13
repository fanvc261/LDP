using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace LDP.ROOT.Helper
{
    public static class ImageExtension
    {
        public static byte[] CreateImageThumbnail(this byte[] image, int width = 50, int height = 50) 
        {
            if (image.Length == 0) return image;
            using (var stream = new System.IO.MemoryStream(image))
            {
                var img = Image.FromStream(stream);
                var thumbnail = img.GetThumbnailImage(width, height, () => false, IntPtr.Zero);

                using (var thumbStream = new System.IO.MemoryStream())
                {
                    thumbnail.Save(thumbStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return thumbStream.GetBuffer();
                }
            }
        }

        public static byte[] CreateImageThumbnail(this byte[] image, int width)
        {
            if (image.Length == 0)
                return image;
            Bitmap b;
            using (var stream = new System.IO.MemoryStream(image))
            {
                var imgToResize = Image.FromStream(stream);

                int sourceWidth = imgToResize.Width;
                int sourceHeight = imgToResize.Height;

                float nPercent = ((float)width / (float)sourceWidth);

                int destWidth = (int)(sourceWidth * nPercent);
                int destHeight = (int)(sourceHeight * nPercent);

                b = new Bitmap(destWidth, destHeight);
                Graphics g = Graphics.FromImage(b);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
                g.Dispose();
                
            }
            return b.CopyImageToByteArray();
        }

        private static byte[] CopyImageToByteArray(this Image theImage)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                theImage.Save(memoryStream, ImageFormat.Jpeg);
                return memoryStream.ToArray();
            }
        }
    }
}