using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Ionic.Zip;

namespace AdminServiceLibrary.Code
{
    public class DirectoryControl
    {
        public bool AddNew(string name, string path)
        {
            string dirPath = Path.Combine(path, name);
            if (!Directory.Exists(dirPath))
            {
                try
                {
                    Directory.CreateDirectory(dirPath);
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
            string dirToCopyPath = Path.Combine(sourcePath, name);
            string dirToPastePath = Path.Combine(destinationPath, name);
            DirectoryInfo dirToCopy = new DirectoryInfo(dirToCopyPath);
            if (Directory.Exists(dirToCopyPath))
            {
                DirectoryInfo[] innerDirs = dirToCopy.GetDirectories();
                AddNew(name, destinationPath);
                FileInfo[] innerFiles = dirToCopy.GetFiles();
                foreach (FileInfo file in innerFiles)
                {
                    string tempSourcePath = Path.Combine(sourcePath, name);
                    string tempDestinPath = Path.Combine(destinationPath, name);
                    FileControl filetoCopy = new FileControl();
                    filetoCopy.CopyAndPaste(file.Name, tempSourcePath, tempDestinPath);
                }
                foreach (DirectoryInfo subdir in innerDirs)
                {
                    string tempSourcePath = Path.Combine(sourcePath, name);
                    string tempDestinPath = Path.Combine(destinationPath, name);
                    CopyAndPaste(subdir.Name, tempSourcePath, tempDestinPath);
                }
            }
            return true;
        }
     
        public bool CutAndPaste(string name, string sourcePath, string destinationPath)
        {
            CopyAndPaste(name, sourcePath, destinationPath);
            Delete(name, sourcePath);
            return true;
        }
     
        public DirectoryInfo GetInfo(string name, string path)
        {
            string dirPath = Path.Combine(path, name);
            return new DirectoryInfo(dirPath);
        }
     
        public bool Delete(string name, string path)
        {
            string dirPath = Path.Combine(path, name);
            if (Directory.Exists(dirPath))
            {
                try
                {
                    Directory.Delete(dirPath);
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
            string dirPath = Path.Combine(path, oldName);
            string dirNewPath = Path.Combine(path, newName);
            Directory.Move(dirPath, dirNewPath);
            return true;
        }

        public bool Compress(string name, string destinationPath)
        {
            string objToComprasePath = Path.Combine(destinationPath, name);
            string objToCompraseName= name;
            string zipName = Path.Combine(destinationPath, objToCompraseName) + ".zip";
            using (ZipFile zip = new ZipFile())
            {
                zip.AddDirectory(objToComprasePath);
                zip.Save(zipName);
            }
            return true;

        }
    }
}
