using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLaborAPI.Accounts.Domain.Model
{
    public class Proposal
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Fee { get; set; }

        public Employer Employer { get; set; }
        public int EmployerId { get; set; }
        public Freelancer Freelancer { get; set; }
        public int FreelancerId { get; set; }


    }
}
