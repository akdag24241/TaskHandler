using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class TaskDefinitionManager : ITaskDefinitionService
    {
        private ITaskDal _taskDal;
        public TaskDefinitionManager()
        {
            _taskDal = new EfTaskDal();
        }

        public void SaveTaskDefinition(TaskDefinition taskDefinition)
        {
            _taskDal.Add(taskDefinition);
        }
    }
}
