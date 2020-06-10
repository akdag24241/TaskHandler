using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Shared;
using System.Reflection;
using System.IO;

namespace HandlerService
{
    public class TaskManager
    {
        private List<TaskContext> _taskList;
        public TaskManager()
        {
            _taskList = new List<TaskContext>();
        }
        
        public void AddQueue(TaskContext context)
        {
            lock (_taskList)
            {
                _taskList.Add(context);
            }
        }
        public void RemoveFromQueue(TaskContext context)
        {
            lock (_taskList)
            {
                _taskList.Remove(context);
            }
        }
        public ITaskHandler FetchNextTask()
        {
            Assembly assembly = null;
            lock (_taskList)
            {
                var task = _taskList.FindAll(x => !x.IsExecuting && 
                                                  x.NextStartDate < DateTime.Now)
                                    .OrderBy(x => x.RunOrderImportance)
                                    .First();
                task.StartDate = DateTime.Now;
                assembly = task.Assembly;
            }
            string assemblyFullName = assembly.FullName;
            Type[] types = assembly.GetTypes();
            ITaskHandler returnObject = assembly.CreateInstance(types[0].FullName) as ITaskHandler;
            return returnObject;
        }

        public void GetAllTasks()
        {
            var result = TaskCreatorFactory.CreateTask(@"C:\\Tasks\\TaskNumber1.dll", DateTime.Now, TaskRunOrderImportance.Critical);
            AddQueue(result);
        }
    }
}
