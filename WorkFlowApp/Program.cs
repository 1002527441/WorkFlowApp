using Microsoft.Extensions.DependencyInjection;
using System;
using WorkflowCore.Interface;

namespace WorkFlowApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices();
            var host = serviceProvider.GetService<IWorkflowHost>();
            host.RegisterWorkflow<HelloWorldWorkflow>();
            host.Start();

            // Demo1:Hello World
            host.StartWorkflow("HelloWorldHenry");

            Console.ReadKey();
            host.Stop();


        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddLogging(); // WorkflowCore需要用到logging service
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WorkflowApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            services.AddWorkflow(x=>x.UseSqlServer(connectionString, true, true));
         

            var serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }


    }
}
