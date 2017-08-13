using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Ionic.Zip;

namespace AdminServiceLibrary
{
    public class Support
    {
        public static bool Compress(string name, string destinationPath, bool isDirectory)
        {
            string objToComprasePath = Path.Combine(destinationPath, name);
            string objToCompraseName;
            if(name.IndexOf('.')>-1)
            {
                objToCompraseName = name.Substring(0, name.IndexOf('.')+1);
            }
            else
            {
                objToCompraseName = name;
            }
            string zipName = Path.Combine(destinationPath, objToCompraseName) + ".zip";
            using (ZipFile zip = new ZipFile())
            {
                if (!isDirectory)
                    zip.AddFile(objToComprasePath);
                else
                    zip.AddDirectory(objToComprasePath);
                zip.Save(zipName);
            }
            return true;
            
        }
    }
}
