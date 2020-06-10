using Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("TaskDefinition", Schema = "TSK")]
    public class TaskDefinition : IEntity
    {
        [Key]
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RunPeriodId { get; set; }
        public DateTime SystemDate { get; set; }
        public string Path { get; set; }
    }
}
