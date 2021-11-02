using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EZLaborAPI.Accounts.Resources
{
    public class SaveProposalResource
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Fee { get; set; }

        public int EmployerId { get; set; }

        public int FreelancerId { get; set; }
    }
}
