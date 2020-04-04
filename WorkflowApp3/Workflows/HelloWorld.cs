using System;
using System.Collections.Generic;
using System.Text;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowApp3
{
    public class HelloWorld : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("Hello World!");
            return ExecutionResult.Next();
        }
    }

    public class ActiveWorld : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("I am activing in the World!");
            return ExecutionResult.Next();
        }
    }

    public class SayHello : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("Say Hello World!");
            return ExecutionResult.Next();
        }
    }


    public class PrintMessage : StepBody
    {
        public string Message = string.Empty;
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("Print a Message");
            return ExecutionResult.Next();
        }
    }


    public class GoodbyeWorld : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("Goodbye World!");
            return ExecutionResult.Next();
        }
    }
}
