using EZLaborAPI.Accounts.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLaborAPI.Accounts.Domain.Services.Communications
{
    public class FreelancerResponse : BaseResponse<Freelancer>
    {
        public FreelancerResponse(Freelancer resource) : base(resource)
        {
        }

        public FreelancerResponse(string message) : base(message)
        {
        }
    }
}
