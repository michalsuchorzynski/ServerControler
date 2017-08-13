using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;
using AdminServiceLibrary.Code;

namespace AdminServiceLibrary
{
    public class AdminService : IAdminService
    {
        #region FileAndDirectoryControle
        public bool AddNewDirectory(string name, string path)
        {
            DirectoryControl control = new DirectoryControl();
            return control.AddNew(name, path);
        }

        public bool AddNewFile(string name, string path)
        {
            FileControl control = new FileControl();
            return control.AddNew(name, path);
        }

        public bool CopyAndPasteDirectory(string name, string sourcePath, string destinationPath)
        {
            DirectoryControl control = new DirectoryControl();
            return control.CopyAndPaste(name,sourcePath,destinationPath);
        }

        public bool CopyAndPasteFile(string name, string sourcePath, string destinationPath)
        {
            FileControl control = new FileControl();
            return control.CopyAndPaste(name, sourcePath, destinationPath);
        }

        public bool CutAndPasteDirectory(string name, string sourcePath, string destinationPath)
        {
            DirectoryControl control = new DirectoryControl();
            control.CopyAndPaste(name, sourcePath, destinationPath);
            control.Delete(name, sourcePath);
            return true;
        }

        public bool CutAndPasteFile(string name, string sourcePath, string destinationPath)
        {
            FileControl control = new FileControl();
            control.CopyAndPaste(name, sourcePath, destinationPath);
            control.Delete(name, sourcePath);
            return true;
        }

        public DirectoryInfo GetDirectoryInfo(string name, string path)
        {
            DirectoryControl control = new DirectoryControl();
            return control.GetInfo(name, path);
        }
                
        public FileInfo GetFileInfo(string name, string path)
        {
            FileControl control = new FileControl();
            return control.GetInfo(name, path);
        }

        public bool DeleteDirectory(string name, string path)
        {
            DirectoryControl control = new DirectoryControl();
            return control.Delete(name, path);
        }

        public bool DeleteFile(string name, string path)
        {
            FileControl control = new FileControl();
            return control.Delete(name, path);
        }

        public bool RenameDirectory(string oldName, string newName, string path)
        {
            DirectoryControl control = new DirectoryControl();
            return control.Rename(oldName, newName, path);
        }

        public bool RenameFile(string oldName, string newName,string path)
        {
            FileControl control = new FileControl();
            return control.Rename(oldName, newName, path);
        }
        #endregion

    }
}
