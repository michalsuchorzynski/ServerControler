using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;

namespace AdminServiceLibrary
{
    public class AdminService : IAdminService
    {
        #region FileAndDirectoryControle
        public bool AddNewDirectory(string name, string path)
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

        public bool AddNewFile(string name, string path)
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

        public bool CopyAndPasteDirectory(string name, string sourcePath, string destinationPath)
        {
            string dirToCopyPath = Path.Combine(sourcePath, name);
            string dirToPastePath = Path.Combine(destinationPath, name);
            DirectoryInfo dirToCopy = new DirectoryInfo(dirToCopyPath);
            if (Directory.Exists(dirToCopyPath))
            {
                DirectoryInfo[] innerDirs = dirToCopy.GetDirectories();
                AddNewDirectory(name, destinationPath);
                FileInfo[] innerFiles = dirToCopy.GetFiles();
                foreach (FileInfo file in innerFiles)
                {
                    string tempSourcePath = Path.Combine(sourcePath, name);
                    string tempDestinPath = Path.Combine(destinationPath, name);
                    CopyAndPasteFile(file.Name, tempSourcePath, tempDestinPath);
                }
                foreach (DirectoryInfo subdir in innerDirs)
                {
                    string tempSourcePath = Path.Combine(sourcePath, name);
                    string tempDestinPath = Path.Combine(destinationPath, name);
                    CopyAndPasteDirectory(subdir.Name, tempSourcePath, tempDestinPath);
                }
            }
            return true;
        }

        public bool CopyAndPasteFile(string name, string sourcePath, string destinationPath)
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

        public bool CutAndPasteDirectory(string name, string sourcePath, string destinationPath)
        {
            CopyAndPasteDirectory(name, sourcePath, destinationPath);
            DeleteDirectory(name, sourcePath);
            return true;
        }

        public bool CutAndPasteFile(string name, string sourcePath, string destinationPath)
        {
            CopyAndPasteFile(name, sourcePath, destinationPath);
            DeleteFile(name, sourcePath);
            return true;
        }

        public void GetDirectoryInfo(string name, string path)
        {
            string dirPath = Path.Combine(path, name);
            DirectoryInfo dir = new DirectoryInfo(dirPath);
            FileInfo[] innerFiles = dir.GetFiles(); 
        }
                
        public void GetFileInfo(string name, string path)
        {
            string filePath = Path.Combine(path, name);
            FileInfo file = new FileInfo(filePath);
        }

        public bool DeleteDirectory(string name, string path)
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

        public bool DeleteFile(string name, string path)
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
        #endregion

    }
}
