using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkflowApp3.Models;
using WorkflowCore.Interface;

namespace WorkflowApp3.Workflows
{
    public class EdcWorkflow : IWorkflow
    {
        public string Id => "EdcWorkflow";

        public int Version => 1;

        public void Build(IWorkflowBuilder<object> builder)
        {
            builder
                .StartWith<HelloWorld>()
                .Then<GoodbyeWorld>();
        }
    }

    public class EdcDataWorkflow : IWorkflow<EdcData>
    {
        public string Id => "EdcDataWorkflow";

        public int Version => 1;

        public void Build(IWorkflowBuilder<EdcData> builder)
        {
            builder
                .StartWith<HelloWorld>()
                .If(data => data.Id < 3).Do(then => then
                        .StartWith<PrintMessage>()
                            .Input(step => step.Message, data => "Passed Id is less than 3")
                )
               .If(data => data.Id < 5).Do(then => then
                        .StartWith<PrintMessage>()
                            .Input(step => step.Message, data => "Passed Id is less than 5")
                )
                .Then<GoodbyeWorld>();
        }
    }
}
