using Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.FileOperations
{
    public class FileLogger : ILogHelper, IDisposable
    {
        private FileStream _fileStream;
        private StreamWriter _streamWriter;
        private string _filePath = @"C:\TaskLogs\";
        public FileLogger()
        {
            string fileFullPath = Path.Combine(_filePath, DateTime.Now.ToString("ddMMyyyy hhmmss")+ ".txt");
            _fileStream = new FileStream(fileFullPath, FileMode.CreateNew);
            _streamWriter = new StreamWriter(_fileStream);
        }

        public void Log(string information, LoggerEnums.LoggingSeverity severity)
        {
            _streamWriter.WriteLineAsync(string.Format("{0} {1} {2}", severity.GetMessage(), " ", information));
            _streamWriter.Flush();
        }

        public void Log(string information)
        {
            _streamWriter.WriteLineAsync(string.Format("{0} {1} {2}", LoggerEnums.LoggingSeverity.Success.GetMessage()
                                                                    , " "
                                                                    , information));
            _streamWriter.Flush();
        }

        public void Dispose()
        {
            _fileStream.Dispose();
        }
    }
}
