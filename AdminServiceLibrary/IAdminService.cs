using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AdminServiceLibrary
{
    [ServiceContract]
    public interface IAdminService
    {
        #region FileAndDirectoryControle

        [OperationContract]
        Boolean AddNewDirectory(string name, string path);

        [OperationContract]
        Boolean AddNewFile(string name, string path);

        [OperationContract]
        Boolean CopyAndPasteDirectory(string name, string sourcePath, string destinationPath);

        [OperationContract]
        Boolean CopyAndPasteFile(string name, string sourcePath, string destinationPath);

        [OperationContract]
        Boolean CutAndPasteDirectory(string name, string sourcePath, string destinationPath);

        [OperationContract]
        Boolean CutAndPasteFile(string name, string sourcePath, string destinationPath);

        [OperationContract]
        void GetDirectoryInfo(string name, string path);

        [OperationContract]
        void GetFileInfo(string name, string path);

        [OperationContract]
        Boolean DeleteDirectory(string name, string path);

        [OperationContract]
        Boolean DeleteFile(string name, string path);

        #endregion

    }
}
