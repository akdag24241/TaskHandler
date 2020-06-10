using System;
using System.Collections.Generic;
using System.Text;
using static Core.Entities.LoggerEnums;

namespace Core.FileOperations
{
    public interface ILogHelper
    {
        void Log(string information, LoggingSeverity severity);
        void Log(string information);
    }
}
