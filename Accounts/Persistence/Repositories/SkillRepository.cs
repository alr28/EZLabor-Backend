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
    public class SkillRepository : BaseRepository, ISkillRepository
    {
        public SkillRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Skill>> ListAsync()
        {
            return await _context.Skills.ToListAsync();
        }

        public async Task AddAsync(Skill skill)
        {
            await _context.Skills.AddAsync(skill);
        }

        public async Task<Skill> FindById(int id)
        {
            return await _context.Skills.FindAsync(id);
        }
        public void Update(Skill skill)
        {
            _context.Skills.Update(skill);
        }

        public void Remove(Skill skill)
        {
            _context.Skills.Remove(skill);
        }



    }
}
