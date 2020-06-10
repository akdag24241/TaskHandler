using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class TaskRunHistory : IEntity
    {
        public int TaskRunHistoryId { get; set; }
        public int TaskId { get; set; }
        public string ExecutionContext { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime SystemDate { get; set; }
    }
}
