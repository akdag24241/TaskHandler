using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace HandlerService
{
    public class TaskCreatorFactory
    {
        public static TaskContext CreateTask(string path, DateTime startDate, TaskRunOrderImportance importance)
        {
            var assembly = Assembly.LoadFrom(path);
            var context = new TaskContext(importance)
            {
                Assembly = assembly,
                IsExecuting = false,
                AssemblyPath = path,
                StartDate = startDate,
            };
            return context;  
        }
        
    }
}
