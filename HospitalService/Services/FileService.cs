using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HospitalService.Services
{
    public class FileService
    {
        public bool CheckIfDirectoryExits(string directoryName, bool createDirectory = false)
        {
            switch (createDirectory)
            {
                case false:
                    {
                        return Directory.Exists(@directoryName);
                    }
                case true:
                    {
                        return !Directory.Exists(@directoryName) ? CreateDirectory(directoryName) : Directory.Exists(@directoryName);
                    }
                default:
                    return false;
            }
        }

        public bool CreateDirectory(string directoryName)
        {
            var exists = Directory.CreateDirectory(@directoryName).Exists;
            return exists;
        }

        public string SaveFileToLocation(HttpPostedFileBase file, string directory, string changeFileName = "default")
        {
            var filename = Path.GetFileName(file.FileName);
            if (changeFileName != "default")
            {
                filename = changeFileName;
            }
            if (filename == null) return null;
            var path = Path.Combine(HttpContext.Current.Server.MapPath(directory), filename);
            CheckIfDirectoryExits(directory, true);
            file.SaveAs(path);
            return path;
        }

    }
}
