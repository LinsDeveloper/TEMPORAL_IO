using System;
using System.Threading.Tasks;
using Temporalio.Workflows;
using TMS.FLOW.Application.Workflows.Models.Activities;
using TMS.FLOW.Workflows.Activities;

namespace TMS.FLOW.Application.Workflows
{
    [Workflow]
    public class InitialWorkflow
    {
        [WorkflowRun]
        public async Task<string> RunAsync(string name)
        {
            var param = new ActivitiesParams("Hello", name);
            return await Workflow.ExecuteActivityAsync(
                (InitialActivity a) => a.MyActivity(param),
                new() { StartToCloseTimeout = TimeSpan.FromMinutes(5) });
        }
    }
}
