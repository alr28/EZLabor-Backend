using EZLaborAPI.Accounts.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLaborAPI.Accounts.Domain.Services.Communications
{
    public class SkillResponse : BaseResponse<Skill>
    {
        public SkillResponse(Skill resource) : base(resource)
        {
        }

        public SkillResponse(string message) : base(message)
        {
        }
    }
}
