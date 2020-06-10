using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class TaskDefinitionDto : IDto
    {
        public string Name { get; set; }
        public string Base64FileContent { get; set; }
        public string Description { get; set; }
        public int RunPeriodId { get; set; }
        public int RunPeriodValue { get; set; }
    }
}
