using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EZLaborAPI.Accounts.Resources
{
    public class SaveSkillResource
    {
        

        [Required]
        public string SkillName { get; set; }

        public int FreelancerId { get; set; }
    }
}
