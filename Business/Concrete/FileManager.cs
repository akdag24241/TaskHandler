using Business.Abstract;
using Core.FileOperations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class FileManager : IFileService
    {
        

        public string SaveToPath(string path, string name, string extension, byte[] payload)
        {
            IFileHelper fileHelper = new Core.FileOperations.FileManager();
            string fullPath = fileHelper.SaveFile(path, name, ".dll", payload);
            return fullPath;
        }
    }
}
