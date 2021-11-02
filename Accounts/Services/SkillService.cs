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
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IUnitOfWork _unitOfWork;


        public SkillService(ISkillRepository skillRepository, IUnitOfWork unitOfWork)
        {
            _skillRepository = skillRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<Skill>> ListAsync()
        {
            return await _skillRepository.ListAsync();
        }


        public async Task<SkillResponse> GetByIdAsync(int id)
        {
            var existingSkill = await _skillRepository.FindById(id);

            if (existingSkill == null)
                return new SkillResponse("Skill not found");
            return new SkillResponse(existingSkill);
        }

        public async Task<SkillResponse> SaveAsync(Skill skill)
        {
            try
            {
                await _skillRepository.AddAsync(skill);
                await _unitOfWork.CompleteAsync();

                return new SkillResponse(skill);
            }
            catch (Exception ex)
            {
                return new SkillResponse($"An error ocurred while saving the skill: {ex.Message}");
            }
        }

        public async Task<SkillResponse> UpdateAsync(int id, Skill skill)
        {
            var existingSkill = await _skillRepository.FindById(id);

            if (existingSkill == null)
                return new SkillResponse("Skill not found");

            existingSkill.SkillName = skill.SkillName;
            //existingSkill.FreelancerId = skill.FreelancerId;

            try
            {
                _skillRepository.Update(existingSkill);
                await _unitOfWork.CompleteAsync();

                return new SkillResponse(existingSkill);
            }
            catch (Exception ex)
            {
                return new SkillResponse($"An error ocurred while updating the skill: {ex.Message}");
            }
        }

        public async Task<SkillResponse> DeleteAsync(int id)
        {
            var existingSkill = await _skillRepository.FindById(id);

            if (existingSkill == null)
                return new SkillResponse("Skill not found");

            try
            {
                _skillRepository.Remove(existingSkill);
                await _unitOfWork.CompleteAsync();

                return new SkillResponse(existingSkill);
            }
            catch (Exception ex)
            {
                return new SkillResponse($"An error ocurred while deleting the skill: {ex.Message}");
            }
        }
    }
}
