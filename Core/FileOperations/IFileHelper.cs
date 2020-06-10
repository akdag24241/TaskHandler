using System;
using System.Collections.Generic;
using System.Text;

namespace Core.FileOperations
{
    public interface IFileHelper
    {
        string SaveFile(string path, string name, string extension, byte[] payload);
        byte[] GetContent(string path);
        byte[] GetContentByKey(string key);
    }
}
