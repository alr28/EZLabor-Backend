using EZLaborAPI.Accounts.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLaborAPI.Accounts.Domain.Persistence.Repositories
{
    public interface IProposalRepository
    {
        Task<IEnumerable<Proposal>> ListAsync();
        Task<IEnumerable<Proposal>> ListByIdAsync(int Id);
        Task<Proposal> FindById(int id);
        Task<IEnumerable<Proposal>> ListByEmployerIdAsync(int employerId);
        Task<IEnumerable<Proposal>> ListByFreelancerIdAsync(int freelancerId);
        //Task<Proposal> FindByEmployerIdAndFreelancerId(int employerId, int freelancerId);
        Task AddAsync(Proposal proposal);

        void Update(Proposal proposal);
        void Remove(Proposal proposal);

        //Task AssignProposal(int employerId, int freelancerId);
        //void UnassignProposal(int employerId, int freelancerId);

    }
}
