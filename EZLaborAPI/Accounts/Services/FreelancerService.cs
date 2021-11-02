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
    public class FreelancerService : IFreelancerService
    {
        private readonly IFreelancerRepository _freelancerRepository;
        private readonly IProposalRepository _proposalRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FreelancerService(IFreelancerRepository freelancerRepository, IProposalRepository proposalRepository, IUnitOfWork unitOfWork)
        {
            _freelancerRepository = freelancerRepository;
            _proposalRepository = proposalRepository;
            _unitOfWork = unitOfWork;
        }

        public FreelancerService(IFreelancerRepository freelancerRepository, IUnitOfWork unitOfWork)
        {
            _freelancerRepository = freelancerRepository;
            _unitOfWork = unitOfWork;
        }




        public async Task<IEnumerable<Freelancer>> ListAsync()
        {
            return await _freelancerRepository.ListAsync();
        }


        public async Task<FreelancerResponse> GetByIdAsync(int id)
        {
            var existingFreelancer = await _freelancerRepository.FindById(id);

            if (existingFreelancer == null)
                return new FreelancerResponse("Freelancer not found");
            return new FreelancerResponse(existingFreelancer);
        }

        public async Task<FreelancerResponse> SaveAsync(Freelancer freelancer)
        {
            try
            {
                await _freelancerRepository.AddAsync(freelancer);
                await _unitOfWork.CompleteAsync();

                return new FreelancerResponse(freelancer);
            }
            catch (Exception ex)
            {
                return new FreelancerResponse($"An error ocurred while saving the freelancer: {ex.Message}");
            }
        }

        public async Task<FreelancerResponse> UpdateAsync(int id, Freelancer freelancer)
        {
            var existingFreelancer = await _freelancerRepository.FindById(id);

            if (existingFreelancer == null)
                return new FreelancerResponse("Freelancer not found");

            existingFreelancer.UserName = freelancer.UserName;
            existingFreelancer.Email = freelancer.Email;
            existingFreelancer.Password = freelancer.Password;
            existingFreelancer.Name = freelancer.Name;
            existingFreelancer.LastName = freelancer.LastName;
            existingFreelancer.About = freelancer.About;
            existingFreelancer.Rating = freelancer.Rating;

            try
            {
                _freelancerRepository.Update(existingFreelancer);
                await _unitOfWork.CompleteAsync();

                return new FreelancerResponse(existingFreelancer);
            }
            catch (Exception ex)
            {
                return new FreelancerResponse($"An error ocurred while updating the freelancer: {ex.Message}");
            }
        }



        public async Task<FreelancerResponse> DeleteAsync(int id)
        {
            var existingFreelancer = await _freelancerRepository.FindById(id);

            if (existingFreelancer == null)
                return new FreelancerResponse("Freelancer not found");

            try
            {
                _freelancerRepository.Remove(existingFreelancer);
                await _unitOfWork.CompleteAsync();

                return new FreelancerResponse(existingFreelancer);
            }
            catch (Exception ex)
            {
                return new FreelancerResponse($"An error ocurred while deleting the freelancer: {ex.Message}");
            }
        }




        /*
        public async Task<IEnumerable<Freelancer>> ListByEmployerId(int employerId)
        {
            var proposals = await _proposalRepository.ListByEmployerIdAsync(employerId);
            var freelancers = proposals.Select(pt => pt.Freelancer).ToList();
            return freelancers;
        }
        */






    }
}
