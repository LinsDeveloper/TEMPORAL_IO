using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Temporalio.Activities;
using TMS.FLOW.Application.Workflows.Models.Activities;

namespace TMS.FLOW.Application.Workflows.Interfaces.Activities
{
    public interface IInitialActivity
    {
        string MyActivity(ActivitiesParams input) => $"{input.Greeting}, {input.Name}!";
    }
}
