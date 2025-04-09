using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.FLOW.Application.Workflows.Models.Activities
{
    public class ActivitiesParams
    {
        public string Greeting { get; set; }
        public string Name { get; set; }

        public ActivitiesParams(string greeting, string name)
        {
            Greeting = greeting;
            Name = name;
        }
    }
}
