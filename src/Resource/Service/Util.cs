using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource.Service
{
    internal class Util
    {
        public static void CreateFolder(string path)
        { 
            var folderPath = path;
            if (path.IndexOf('.') > 0)
                folderPath = path.Substring(0, path.LastIndexOf(@"\"));

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
        }

        public static string GetAppSettings(string key)
        {
            var obj = ConfigurationManager.AppSettings[key];

            if (obj == null)
                return string.Empty;

            return obj.ToString();
        }
    }
}
