using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Ionic.Zip;

namespace AdminServiceLibrary.Code
{
    public class FileControl
    {
        public bool AddNew(string name, string path)
        {
            string filePath = Path.Combine(path, name);
            if (!File.Exists(filePath))
            {
                try
                {
                    File.Create(filePath);
                }
                catch (Exception e)
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CopyAndPaste(string name, string sourcePath, string destinationPath)
        {
            string fileToCopyPath = Path.Combine(sourcePath, name);
            string fileToPastePath = Path.Combine(destinationPath, name);
            if (File.Exists(fileToCopyPath) && !File.Exists(fileToPastePath))
            {
                try
                {
                    File.Copy(fileToCopyPath, fileToPastePath);
                }
                catch (Exception e)
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool CutAndPaste(string name, string sourcePath, string destinationPath)
        {
            CopyAndPaste(name, sourcePath, destinationPath);
            Delete(name, sourcePath);
            return true;
        }
        
        public FileInfo GetInfo(string name, string path)
        {
            string filePath = Path.Combine(path, name);
            return new FileInfo(filePath);
        }
                
        public bool Delete(string name, string path)
        {
            string filePath = Path.Combine(path, name);
            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                }
                catch (Exception e)
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool Rename(string oldName, string newName, string path)
        {
            string filePath = Path.Combine(path, oldName);
            string fileNewPath = Path.Combine(path, newName);
            File.Move(filePath, fileNewPath);
            return true;
        }

        public bool Compress(string name, string destinationPath, bool isDirectory)
        {
            string objToComprasePath = Path.Combine(destinationPath, name);
            string objToCompraseName = name.Substring(0, name.IndexOf('.') + 1); ;
            string zipName = Path.Combine(destinationPath, objToCompraseName) + ".zip";
            using (ZipFile zip = new ZipFile())
            {
                zip.AddFile(objToComprasePath);
                zip.Save(zipName);
            }
            return true;

        }
    }
}
