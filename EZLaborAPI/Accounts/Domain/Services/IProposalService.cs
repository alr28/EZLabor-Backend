using EZLaborAPI.Accounts.Domain.Model;
using EZLaborAPI.Accounts.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLaborAPI.Accounts.Domain.Services
{
    public interface IProposalService
    {
        Task<IEnumerable<Proposal>> ListAsync();
        Task<IEnumerable<Proposal>> ListByIdAsync(int id);
        Task<IEnumerable<Proposal>> ListByEmployerIdAsync(int employerId);
        Task<IEnumerable<Proposal>> ListByFreelancerIdAsync(int freelancerId);
        //Task<ProposalResponse> AssignProposalAsync(int employertId, int freelancerId);
        //Task<ProposalResponse> UnassignProposalAsync(int employerId, int freelancerId);

        Task<ProposalResponse> SaveAsync(Proposal proposal);
        Task<ProposalResponse> UpdateAsync(int id, Proposal proposal);
        Task<ProposalResponse> DeleteAsync(int id);


    }
}
