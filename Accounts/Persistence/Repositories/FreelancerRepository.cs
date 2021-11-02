using EZLaborAPI.Accounts.Domain.Model;
using EZLaborAPI.Accounts.Domain.Persistence.Repositories;
using EZLaborAPI.Commons.Domain.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLaborAPI.Accounts.Persistence.Repositories
{
    public class FreelancerRepository : BaseRepository, IFreelancerRepository
    {
        public FreelancerRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Freelancer>> ListAsync()
        {
            return await _context.Freelancers.ToListAsync();
        }

        public async Task AddAsync(Freelancer freelancer)
        {
            await _context.Freelancers.AddAsync(freelancer);
        }

        public async Task<Freelancer> FindById(int id)
        {
            return await _context.Freelancers.FindAsync(id);
        }

        public void Remove(Freelancer freelancer)
        {
            _context.Freelancers.Remove(freelancer);
        }

        public void Update(Freelancer freelancer)
        {
            _context.Freelancers.Update(freelancer);
        }

    }
}
