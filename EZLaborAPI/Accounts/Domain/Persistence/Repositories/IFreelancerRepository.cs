using EZLaborAPI.Accounts.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLaborAPI.Accounts.Domain.Persistence.Repositories
{
    public interface IFreelancerRepository
    {
        Task<IEnumerable<Freelancer>> ListAsync();
        Task AddAsync(Freelancer freelancer);
        Task<Freelancer> FindById(int id);
        void Update(Freelancer freelancer);
        void Remove(Freelancer freelancer);
    }
}
