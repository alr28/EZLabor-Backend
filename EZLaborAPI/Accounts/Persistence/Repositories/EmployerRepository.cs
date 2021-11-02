﻿
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
    public class EmployerRepository : BaseRepository, IEmployerRepository
    {
        public EmployerRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Employer>> ListAsync()
        {
            return await _context.Employers.ToListAsync();
        }

        public async Task AddAsync(Employer employer)
        {
            await _context.Employers.AddAsync(employer);
        }

        public async Task<Employer> FindById(int id)
        {
            return await _context.Employers.FindAsync(id);
        }

        public void Remove(Employer employer)
        {
            _context.Employers.Remove(employer);
        }

        public void Update(Employer employer)
        {
            _context.Employers.Update(employer);
        }

    }
}
