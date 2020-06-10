using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.FileOperations;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HandlerService
{
    public class Worker : BackgroundService
    {
        
        private readonly ILogHelper _logHelper;
        private readonly TaskManager _taskManager;
        public Worker(ILogHelper logHelper)
        {
            _logHelper = logHelper;
            _taskManager = new TaskManager();
            _taskManager.GetAllTasks();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var task = _taskManager.FetchNextTask();
                object[] param = new object[] { 1, 2, 3 };
                var returnObject = await Task.Factory.StartNew(() =>
                {
                    var returnObject = task.Execute(param);
                    return returnObject;
                });
            
                _logHelper.Log("Started at " + DateTime.Now.ToString("ddMMyyyy hhMMssFFF") + returnObject.ToString());
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
