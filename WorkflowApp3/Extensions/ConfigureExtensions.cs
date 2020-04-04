using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Interface;
using WorkflowApp3.Models;
using WorkflowApp3.Workflows;



namespace WorkflowApp3.Extensions
{
    public static class ConfigureExtensions
    {
  
        public static IApplicationBuilder UseWorkflow(this IApplicationBuilder app)
        {
            var host = app.ApplicationServices.GetService<IWorkflowHost>();
            host.RegisterWorkflow<EdcWorkflow>();
            host.RegisterWorkflow<EdcDataWorkflow, EdcData>();
            host.Start();

            var appLifetime = app.ApplicationServices.GetService<IApplicationLifetime>();
            appLifetime.ApplicationStopping.Register(() =>
            {
                host.Stop();
            });

            return app;
        }
    }
}
