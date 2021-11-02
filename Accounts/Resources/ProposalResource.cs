using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLaborAPI.Accounts.Resources
{
    public class ProposalResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Fee { get; set; }

        public int EmployerId { get; set; }
        public EmployerResource Employer { get; set; }

        public int FreelancerId { get; set; }

        public FreelancerResource Freelancer {get;set;}

    }
}
