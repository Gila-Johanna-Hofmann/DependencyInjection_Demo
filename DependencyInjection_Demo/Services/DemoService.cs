using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection_Demo.Services
{
    internal interface IDemoService
    {
        void doSomething();
    }

    internal class DemoService : IDemoService
    {
        private readonly ILogger<DemoService> _logger;

        //this constructor shows further dependency injection that will autmatically be handled by the DI-container, no further code needed
        //the Logger doesn'T even have to be registered in the DI-container, it will be injected automatically
        public DemoService(ILogger<DemoService> logger)
            => _logger = logger;
        
        public void doSomething()
        {
            Console.WriteLine("DemoService runs");
            _logger.LogInformation("Logging from DemoService works.");
        }
    }
}
