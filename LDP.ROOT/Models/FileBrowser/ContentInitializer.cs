using System.IO;
using System.Web;
using System;

namespace LDP.ROOT.Models
{
    public class ContentInitializer
    {
        private string rootFolder;
        private string[] foldersToCopy;
        private string prettyName;

        public ContentInitializer(string rootFolder, string[] foldersToCopy, string prettyName)
        {
            this.rootFolder = rootFolder;
            this.foldersToCopy = foldersToCopy;
            this.prettyName = prettyName;
        }

        private string UserID
        {
            get
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    var obj = HttpContext.Current.Session["UserID"];
                    if (obj == null)
                    {
                        HttpContext.Current.Session["UserID"] = obj = DateTime.Now.Ticks.ToString();
                    }
                    return (string)obj;
                }
                else
                {
                    return "usertemp";
                }
            }
        }

        public string CreateUserFolder(System.Web.HttpServerUtility server)
        {
            //var virtualPath = Path.Combine(rootFolder, Path.Combine("UserFiles", UserID), prettyName);

            //var path = server.MapPath(virtualPath);
            //if (!Directory.Exists(path))
            //{
            //    Directory.CreateDirectory(path);
            //    foreach (var sourceFolder in foldersToCopy)
            //    {
            //        CopyFolder(server.MapPath(sourceFolder), path);
            //    }
            //}
            //return virtualPath;
            return Path.Combine(rootFolder, "img");
        }

        private void CopyFolder(string source, string destination)
        {
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }

            foreach (var file in Directory.EnumerateFiles(source))
            {
                var dest = Path.Combine(destination, Path.GetFileName(file));
                System.IO.File.Copy(file, dest);
            }

            foreach (var folder in Directory.EnumerateDirectories(source))
            {
                var dest = Path.Combine(destination, Path.GetFileName(folder));
                CopyFolder(folder, dest);
            }
        }
    }
}