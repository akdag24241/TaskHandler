using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Business.Abstract;
using Entities;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskHandlerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskDefinitionController : ControllerBase
    {
        private IFileService _fileService;
        private ITaskDefinitionService _taskDefinitionService;
        public TaskDefinitionController(IFileService fileService, ITaskDefinitionService taskDefinitionService)
        {
            _fileService = fileService;
            _taskDefinitionService = taskDefinitionService;
        }

        [HttpPost("savetask")]
        public IActionResult SaveTask(TaskDefinitionDto task)
        {
            
            string serverRootPathForFileManagementSystem = @"C:\\Tasks\";
            string fileName = Guid.NewGuid().ToString();
            byte[] content = Convert.FromBase64String(task.Base64FileContent);
            string fullPath = _fileService.SaveToPath(serverRootPathForFileManagementSystem, fileName, ".dll", content);

            _taskDefinitionService.SaveTaskDefinition(new TaskDefinition()
            {
                Description = task.Description,
                Name = task.Name,
                Path = fullPath,
                RunPeriodId = task.RunPeriodId,
                SystemDate = DateTime.Now
            });


            return Ok();
        }


        [HttpPost("savefile")]
        public void SaveFile(IFormFile file)
        {
            using(MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                _fileService.SaveToPath("deneme", "deneme", "deneme", ms.ToArray()); 
            }
        }
    }
}