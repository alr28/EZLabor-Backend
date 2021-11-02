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
    public class EmployerService : IEmployerService
    {
        private readonly IEmployerRepository _employerRepository;
        private readonly IProposalRepository _proposalRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EmployerService(IEmployerRepository employerRepository, IProposalRepository proposalRepository, IUnitOfWork unitOfWork)
        {
            _employerRepository = employerRepository;
            _proposalRepository = proposalRepository;
            _unitOfWork = unitOfWork;
        }

        public EmployerService(IEmployerRepository employerRepository, IUnitOfWork unitOfWork)
        {
            _employerRepository = employerRepository;
            _unitOfWork = unitOfWork;
        }



        public async Task<IEnumerable<Employer>> ListAsync()
        {
            return await _employerRepository.ListAsync();
        }

        public async Task<EmployerResponse> GetByIdAsync(int id)
        {
            var existingEmployer = await _employerRepository.FindById(id);

            if (existingEmployer == null)
                return new EmployerResponse("Employer not found");
            return new EmployerResponse(existingEmployer);
        }

        public async Task<EmployerResponse> SaveAsync(Employer employer)
        {
            try
            {
                await _employerRepository.AddAsync(employer);
                await _unitOfWork.CompleteAsync();

                return new EmployerResponse(employer);
            }
            catch (Exception ex)
            {
                return new EmployerResponse($"An error ocurred while saving the employer: {ex.Message}");
            }
        }

        public async Task<EmployerResponse> UpdateAsync(int id, Employer employer)
        {
            var existingEmployer = await _employerRepository.FindById(id);

            if (existingEmployer == null)
                return new EmployerResponse("Employer not found");

            existingEmployer.UserName = employer.UserName;
            existingEmployer.Email = employer.Email;
            existingEmployer.Password = employer.Password;
            existingEmployer.Name = employer.Name;
            existingEmployer.LastName = employer.LastName;

            try
            {
                _employerRepository.Update(existingEmployer);
                await _unitOfWork.CompleteAsync();

                return new EmployerResponse(existingEmployer);
            }
            catch (Exception ex)
            {
                return new EmployerResponse($"An error ocurred while updating the employer: {ex.Message}");
            }
        }

        public async Task<EmployerResponse> DeleteAsync(int id)
        {
            var existingEmployer = await _employerRepository.FindById(id);

            if (existingEmployer == null)
                return new EmployerResponse("Employer not found");

            try
            {
                _employerRepository.Remove(existingEmployer);
                await _unitOfWork.CompleteAsync();

                return new EmployerResponse(existingEmployer);
            }
            catch (Exception ex)
            {
                return new EmployerResponse($"An error ocurred while deleting the employer: {ex.Message}");
            }
        }



        /*

        public async Task<IEnumerable<Employer>> ListByFreelancerId(int freelancerId)
        {
            var proposals = await _proposalRepository.ListByFreelancerIdAsync(freelancerId);
            var employers = proposals.Select(pt => pt.Employer).ToList();
            return employers;
        }
        */






    }
}
