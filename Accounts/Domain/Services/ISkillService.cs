using EZLaborAPI.Accounts.Domain.Model;
using EZLaborAPI.Accounts.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLaborAPI.Accounts.Domain.Services
{
    public interface ISkillService
    {
        Task<IEnumerable<Skill>> ListAsync();
        Task<SkillResponse> GetByIdAsync(int id);
        Task<SkillResponse> SaveAsync(Skill skill);
        Task<SkillResponse> UpdateAsync(int id, Skill skill);
        Task<SkillResponse> DeleteAsync(int id);

    }
}
