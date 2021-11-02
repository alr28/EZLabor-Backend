using EZLaborAPI.Accounts.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLaborAPI.Accounts.Domain.Services.Communications
{
    public class ProposalResponse : BaseResponse<Proposal>
    {
        public ProposalResponse(Proposal resource) : base(resource)
        {
        }

        public ProposalResponse(string message) : base(message)
        {
        }

    }
}
