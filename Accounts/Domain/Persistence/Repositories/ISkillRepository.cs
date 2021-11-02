using EZLaborAPI.Accounts.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLaborAPI.Accounts.Domain.Persistence.Repositories
{
    public interface ISkillRepository
    {
        Task<IEnumerable<Skill>> ListAsync();
        Task AddAsync(Skill skill);
        Task<Skill> FindById(int id);
        void Update(Skill skill);
        void Remove(Skill skill);
    }
}
