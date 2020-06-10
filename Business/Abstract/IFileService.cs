using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IFileService
    {
        string SaveToPath(string path, string name, string extension, byte[] payload);
    }
}
