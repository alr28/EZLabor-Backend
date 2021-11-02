using EZLaborAPI.Accounts.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLaborAPI.Accounts.Domain.Persistence.Repositories
{
    public interface IEmployerRepository
    {
        Task<IEnumerable<Employer>> ListAsync();
        Task AddAsync(Employer employer);
        Task<Employer> FindById(int id);
        void Update(Employer employer);
        void Remove(Employer employer);

    }
}
