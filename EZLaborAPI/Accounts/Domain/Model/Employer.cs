using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLaborAPI.Accounts.Domain.Model
{
    public class Employer : User
    {

        public IList<Proposal> Proposals { get; set; } = new List<Proposal>();

        /*
        
        public List<Offer> Offers { get; set; }
         
         */

    }
}
