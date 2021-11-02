using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLaborAPI.Accounts.Domain.Model
{
    public class Skill
    {
        public int Id { get; set; }
        public string SkillName { get; set; }
        public int FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }

    }
}
