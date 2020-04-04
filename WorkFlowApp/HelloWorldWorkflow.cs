using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;

namespace WorkFlowApp
{

    public class IfStatementWorkflow : IWorkflow<MyData>
    {
        public string Id => "if-sample";

        public int Version => 1;

        public void Build(IWorkflowBuilder<MyData> builder)
        {
            builder
                .StartWith<SayHello>()
                .If(data => data.Counter < 3).Do(then => then
                        .StartWith<PrintMessage>()
                            .Input(step => step.Message, data => "Outcome is less than 3")
                )
               .If(data => data.Counter < 5).Do(then => then
                        .StartWith<PrintMessage>()
                            .Input(step => step.Message, data => "Outcome is less than 5")
                            
                )
                .Then<GoodbyeWorld>();
        }
    }

    public class DelayWorkflow : IWorkflow
    {
        public string Id => "Delay-Task";

        public int Version =>1;

        public void Build(IWorkflowBuilder<object> builder)
        {
            builder
                    .StartWith(context => Console.WriteLine("Hello"))
                    .Schedule(data => TimeSpan.FromSeconds(5)).Do(schedule => schedule
                    .StartWith(context => Console.WriteLine("Doing scheduled tasks"))
                )
                    .Then(context => Console.WriteLine("Doing normal tasks"));
        }
    }



    public class HelloWorldWorkflow:IWorkflow
    {
        public string Id => "HelloWorldHenry";

        public int Version => 1;

        public void Build(IWorkflowBuilder<object> builder)
        {
            builder
                .StartWith<HelloWorld>()
                .Then<ActiveWorld>()
                .Then<GoodbyeWorld>();
        }
    }

 

    public class MyData
    {
        public int Counter { get; set; }
    }
}
