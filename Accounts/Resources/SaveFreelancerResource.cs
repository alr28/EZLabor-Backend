using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EZLaborAPI.Accounts.Resources
{
    public class SaveFreelancerResource
    {
        [Required]
        [MaxLength(25)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(25)]
        public string Email { get; set; }
        [Required]
        [MaxLength(25)]
        public string Password { get; set; }
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required]
        [MaxLength(25)]
        public string LastName { get; set; }


        public int Rating { get; set; }
        public string About { get; set; }
    }

}
