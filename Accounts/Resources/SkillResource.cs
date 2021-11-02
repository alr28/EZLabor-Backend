using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLaborAPI.Accounts.Resources
{
    public class SkillResource
    {
        public int Id { get; set; }
        public string SkillName { get; set; }
        public int FreelancerId { get; set; }
        public FreelancerResource Freelancer { get; set; }
        
    }
}
