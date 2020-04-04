using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkflowApp3.Models;
using WorkflowCore.Interface;

namespace WorkflowApp3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController:ControllerBase
    {
        private  IWorkflowController _workflowService;

        public ValuesController(IWorkflowController workflowService)
        {
            _workflowService = workflowService;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            await _workflowService.StartWorkflow("EdcWorkflow");
            return new string[] { "EdcWorkflow v1" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            await _workflowService.StartWorkflow("EdcDataWorkflow", new EdcData() { Id = id });
            return "EdcDataWorkflow v1";
        }
    }
}
