using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection_Demo.Services
{
    /// <summary>
    /// This is the interface for the DemoService. It is used to register the service in the DI-container.
    /// </summary>
    internal interface IDemoService
    {
        void doSomething();
    }

    /// <summary>
    /// This is the implementation of the DemoService. It is registered in the DI-container.
    /// </summary>
    internal class DemoService : IDemoService
    {
        //the logger will be used by the instance of DemoService via Dependency Injection
        private readonly ILogger<DemoService> _logger;

        //this constructor shows further dependency injection that will autmatically be handled by the DI-container
        //the Logger doesn't even have to be registered in the DI-container, it will be injected automatically
        public DemoService(ILogger<DemoService> logger)
            => _logger = logger;
        
        public void doSomething()
        {
            Console.WriteLine("DemoService runs");
            _logger.LogInformation("Logging from DemoService works.");
        }
    }
}
