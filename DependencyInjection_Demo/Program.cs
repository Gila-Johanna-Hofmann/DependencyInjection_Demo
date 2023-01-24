using DependencyInjection_Demo.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DependencyInjection_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //Add NuGET Packages: Microsoft.Extensions.DependencyInjection, Microsoft.Extensions.Hosting

            //this method of dependency injection is not to be used in classes! The configuration and calling of services should be in one place --> do not use the service locator pattern
            //use the Host-Interface to configure services with dependency injection
            //the CreateDefaultbuilder does a lot of stuff, e.g. configuring logging, configuration, etc. (Look at the Class Description!)
            //the host is also the dependency injection container, which manages and remembers all the services and their implementation
            IHost _host = Host.CreateDefaultBuilder().ConfigureServices(services => 
            {
                //Configure Services here
                //the application service is configured with a lifetime/scope (there are singleton, transient and scoped lifetimes for services)
                //the container now knows that it should intantiate the IApplication Interface with the Application-Implementetion when called upon
                // --> for DBContext: the AddDbContext-Method already has the DbContext-Interface i´n it, it just needs the implementation iT's supposed to use when the DbContext is called
                services.AddSingleton<IDemoService, DemoService>();
            })
                .Build();

            //call the dependency by telling the DI-container to instantiate the called-for service
            var demo = _host.Services.GetRequiredService<IDemoService>();
            demo.doSomething();

            //What is the purpose of getting a class like the DemoService from Dependency Injection?
            /* When the DI-container instantiates the registered services/classes, it automatically looks for further dependencies form that classes and injects them too
             * So all necessary dependencies are taken care of by the container (see constructor of DemoService for an example).
             */

        }
    }
}