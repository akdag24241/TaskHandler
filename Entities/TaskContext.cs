using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Entities
{
    public class TaskContext
    {
        public TaskContext(TaskRunOrderImportance runOrderImportance)
        {
            UUID = Guid.NewGuid().ToString();
            TimeoutInterval = runOrderImportance.GetHashCode() * 2;
            RunOrderImportance = runOrderImportance;
        }
        public bool IsExecuting { get; set; }
        public string UUID { get; }
        public DateTime StartDate { get; set; }
        public int TimeoutInterval { get; }
        public TaskRunOrderImportance RunOrderImportance { get; }
        public Assembly Assembly { get; set; }
        public DateTime NextStartDate { get; set; }
        public string AssemblyPath { get; set; }
    }

    public enum TaskRunOrderImportance : int
    {
        Low = 1,
        Medium = 2,
        High = 3,
        Critical = 4
    }
}
