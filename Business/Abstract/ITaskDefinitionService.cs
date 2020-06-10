using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ITaskDefinitionService
    {
        void SaveTaskDefinition(TaskDefinition taskDefinition);
    }
}
