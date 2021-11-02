using EZLaborAPI.Accounts.Domain.Model;
using EZLaborAPI.Accounts.Domain.Persistence.Repositories;
using EZLaborAPI.Accounts.Domain.Services;
using EZLaborAPI.Accounts.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLaborAPI.Accounts.Services
{
    public class ProposalService : IProposalService
    {
        private readonly IProposalRepository _proposalRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProposalService(IProposalRepository proposalRepository, IUnitOfWork unitOfWork)
        {
            _proposalRepository = proposalRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<Proposal>> ListAsync()
        {
            return await _proposalRepository.ListAsync();
        }

        public async Task<IEnumerable<Proposal>> ListByIdAsync(int id)
        {
            return await _proposalRepository.ListByIdAsync(id);
        }

        public async Task<IEnumerable<Proposal>> ListByEmployerIdAsync(int employerId)
        {
            return await _proposalRepository.ListByEmployerIdAsync(employerId);
        }

        public async Task<IEnumerable<Proposal>> ListByFreelancerIdAsync(int freelancerId)
        {
            return await _proposalRepository.ListByFreelancerIdAsync(freelancerId);
        }


        public async Task<ProposalResponse> SaveAsync(Proposal proposal)
        {
            try
            {
                await _proposalRepository.AddAsync(proposal);
                await _unitOfWork.CompleteAsync();

                return new ProposalResponse(proposal);
            }
            catch (Exception ex)
            {
                return new ProposalResponse($"An error ocurred while saving the proposal: {ex.Message}");
            }
        }

        public async Task<ProposalResponse> UpdateAsync(int id, Proposal proposal)
        {
            var existingProposal = await _proposalRepository.FindById(id);

            if (existingProposal == null)
                return new ProposalResponse("Proposal not found");

            existingProposal.Title = proposal.Title;
            existingProposal.Description = proposal.Description;
            existingProposal.Fee = proposal.Fee;
            //existingProposal.EmployerId = proposal.EmployerId;
            //existingProposal.FreelancerId = proposal.FreelancerId;

            //existingSkill.FreelancerId = skill.FreelancerId;

            try
            {
                _proposalRepository.Update(existingProposal);
                await _unitOfWork.CompleteAsync();

                return new ProposalResponse(existingProposal);
            }
            catch (Exception ex)
            {
                return new ProposalResponse($"An error ocurred while updating the proposal: {ex.Message}");
            }
        }

        public async Task<ProposalResponse> DeleteAsync(int id)
        {
            var existingProposal = await _proposalRepository.FindById(id);

            if (existingProposal == null)
                return new ProposalResponse("Proposal not found");

            try
            {
                _proposalRepository.Remove(existingProposal);
                await _unitOfWork.CompleteAsync();

                return new ProposalResponse(existingProposal);
            }
            catch (Exception ex)
            {
                return new ProposalResponse($"An error ocurred while deleting the proposal: {ex.Message}");
            }
        }




        /*

        public async Task<ProposalResponse> AssignProposalAsync(int employerId, int freelancerId)
        {
            try
            {

                await _proposalRepository.AssignProposal(employerId, freelancerId);
                await _unitOfWork.CompleteAsync();

                Proposal proposal = await _proposalRepository.FindByEmployerIdAndFreelancerId(employerId, freelancerId);

                return new ProposalResponse(proposal);
            }
            catch (Exception ex)
            {
                return new ProposalResponse($"An error ocurred while assigning Freelancer to Employer: {ex.Message}");
            }
        }

         public async Task<ProposalResponse> UnassignProposalAsync(int employerId, int freelancerId)
        {
            try
            {
                Proposal proposal = await _proposalRepository.FindByEmployerIdAndFreelancerId(employerId, freelancerId);
                _proposalRepository.UnassignProposal(employerId, freelancerId);
                await _unitOfWork.CompleteAsync();

                return new ProposalResponse(proposal);
            }
            catch (Exception ex)
            {
                return new ProposalResponse($"An error ocurred while unassigning Freelancer to Employer: {ex.Message}");
            }
        }

        */






    }
}
