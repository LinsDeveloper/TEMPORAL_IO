using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Temporalio.Workflows;
using System.Threading.Tasks;

namespace TMS.FLOW.Application.Workflows.Interfaces
{
    [Workflow]
    public interface IInitialWorkflow
    {
        Task<string> StartWorkflow();
    }
}
