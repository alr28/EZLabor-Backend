using EZLaborAPI.Accounts.Domain.Model;
using EZLaborAPI.Accounts.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLaborAPI.Accounts.Domain.Services
{
    public interface IEmployerService
    {
        Task<IEnumerable<Employer>> ListAsync();
        //Task<IEnumerable<Employer>> ListByFreelancerId(int freelancerId);
        Task<EmployerResponse> GetByIdAsync(int id);
        Task<EmployerResponse> SaveAsync(Employer employer);
        Task<EmployerResponse> UpdateAsync(int id, Employer employer);
        Task<EmployerResponse> DeleteAsync(int id);
    }
}
