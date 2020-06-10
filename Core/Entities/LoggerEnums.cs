using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class LoggerEnums
    {
        public enum LoggingSeverity : int
        {
            Success = 0,
            Error = 1,
            Timeout = 2
        };
    }
    public static class LoggerExtension
    {
        public static string GetMessage(this LoggerEnums.LoggingSeverity severity)
        {
            switch (severity.GetHashCode())
            {
                case 0:
                    return "Success";
                case 1:
                    return "Error";
                case 2:
                    return "Timeout";
                default:
                    return "UnknownSeverity";
            }
        }

    }

}
