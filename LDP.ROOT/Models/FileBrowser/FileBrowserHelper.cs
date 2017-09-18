using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LDP.ROOT.Models.FileBrowser
{
    public  class FileBrowserHelper
    {
        public string DefaultImageFilter = "*.png,*.gif,*.jpg,*.jpeg";
        private const string DefaultFileFilter = "*.txt,*.doc,*.docx,*.xls,*.xlsx,*.ppt,*.pptx,*.zip,*.rar,*.jpg,*.jpeg,*.gif,*.png";
        private const string contentFolderRoot = "~/data/";
        private const string prettyName = "Images/";
        private static readonly string[] foldersToCopy = new[] { "~/data/editor/" };

        
        private readonly ContentInitializer contentInitializer;
        private readonly ThumbnailCreator thumbnailCreator;

        public string ContentPath
        {
            get
            {
                return contentInitializer.CreateUserFolder(HttpContext.Current.Server);
            }
        }

        public string DefaultFilter { get; set; }

        public FileBrowserHelper (bool isImage)
        {
            DefaultFilter = isImage ? DefaultImageFilter : DefaultFileFilter;
            contentInitializer = new ContentInitializer(contentFolderRoot, foldersToCopy, prettyName);
            thumbnailCreator = new ThumbnailCreator();
        }
        private  string ToAbsolute(string virtualPath)
        {
            return VirtualPathUtility.ToAbsolute(virtualPath);
        }

        public  string CombinePaths(string basePath, string relativePath)
        {
            return VirtualPathUtility.Combine(VirtualPathUtility.AppendTrailingSlash(basePath), relativePath);
        }

        public  bool AuthorizeRead(string path)
        {
            return CanAccess(path);
        }

        public  bool CanAccess(string path)
        {
            return path.StartsWith(ToAbsolute(ContentPath), StringComparison.OrdinalIgnoreCase);
        }

        public string NormalizePath(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return ToAbsolute(ContentPath);
            }

            return CombinePaths(ToAbsolute(ContentPath), path);
        }

        public  bool AuthorizeThumbnail(string path)
        {
            return CanAccess(path);
        }

        public  bool AuthorizeFile(string path)
        {
            return CanAccess(path) && IsValidFile(Path.GetExtension(path));
        }

        public  bool AuthorizeCreateDirectory(string path, string name)
        {
            return CanAccess(path);
        }

        public  bool AuthorizeDeleteFile(string path)
        {
            return CanAccess(path);
        }

        public  bool AuthorizeDeleteDirectory(string path)
        {
            return CanAccess(path);
        }

        public  bool AuthorizeUpload(string path, HttpPostedFileBase file)
        {
            return CanAccess(path) && IsValidFile(file.FileName);
        }

        private bool IsValidFile(string fileName)
        {
            var extension = Path.GetExtension(fileName);
            var allowedExtensions = DefaultFilter.Split(',');

            return allowedExtensions.Any(e => e.EndsWith(extension, StringComparison.InvariantCultureIgnoreCase));
        }


        public void CreateThumbnail(string physicalPath, int ThumbnailWidth, int ThumbnailHeight)
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


        public virtual void DeleteFile(string path)
        {
            if (!AuthorizeDeleteFile(path))
            {
                throw new HttpException(403, "Forbidden");
            }

            var physicalPath = HttpContext.Current.Server.MapPath(path);

            if (System.IO.File.Exists(physicalPath))
            {
                System.IO.File.Delete(physicalPath);
            }
        }

        public virtual void DeleteDirectory(string path)
        {
            if (!AuthorizeDeleteDirectory(path))
            {
                throw new HttpException(403, "Forbidden");
            }

            var physicalPath = HttpContext.Current.Server.MapPath(path);

            if (Directory.Exists(physicalPath))
            {
                Directory.Delete(physicalPath, true);
            }
        }

    }
}