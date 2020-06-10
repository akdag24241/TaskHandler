using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.FileOperations
{
    public class FileManager : IFileHelper
    {
        

        /// <summary>
        /// Upload to file to servers file storage system
        /// </summary>
        /// <param name="path"></param>
        /// <param name="payload"></param>
        /// <returns>Full path of uploaded file</returns>
        public string SaveFile(string path, string name, string extension, byte[] payload)
        {
            string fullPath = Path.Combine(path, name + "." + extension);
            using (FileStream fs = new FileStream(fullPath, FileMode.Create))
            {
                fs.Write(payload, 0, payload.Length);
                fs.Close();
            }
            return fullPath;
        }

        public byte[] GetContent(string path)
        {
            string fullPath = Path.Combine(path);
            byte[] byteArr = null;
            using (FileStream fs = new FileStream(fullPath, FileMode.Open))
            {
                

            }
            return byteArr;
        }

        public byte[] GetContentByKey(string key)
        {
            return null;
        }

        
    }
}
