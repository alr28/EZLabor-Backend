using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLaborAPI.Accounts.Domain.Model
{
    public class Freelancer : User
    {
        public int Rating { get; set; }
        public string About { get; set; }
        public IList<Skill> Skills { get; set; } = new List<Skill>();
        public IList<Proposal> Proposals { get; set; } = new List<Proposal>();

        /*
         
        

        public List<Postulation> Postulations { get; set; }

         */

    }
}
