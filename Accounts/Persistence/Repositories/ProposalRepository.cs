﻿using EZLaborAPI.Accounts.Domain.Model;
using EZLaborAPI.Accounts.Domain.Persistence.Repositories;
using EZLaborAPI.Commons.Domain.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLaborAPI.Accounts.Persistence.Repositories
{
    public class ProposalRepository : BaseRepository, IProposalRepository
    {
        public ProposalRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Proposal>> ListAsync()
        {
            return await _context.Proposals
                .Include(pt => pt.Freelancer)
                .Include(pt => pt.Employer)
                .ToListAsync();
        }

        public async Task<IEnumerable<Proposal>> ListByIdAsync(int Id)
        {
            return await _context.Proposals
                .Where(pt => pt.Id == Id)
                .Include(pt => pt.Freelancer)
                .Include(pt => pt.Employer)
                .ToListAsync();
        }
        public async Task<Proposal> FindById(int id)
        {
            return await _context.Proposals.FindAsync(id);
        }
        public async Task<IEnumerable<Proposal>> ListByEmployerIdAsync(int employerId)
        {
            return await _context.Proposals
                .Where(pt => pt.EmployerId == employerId)
                .Include(pt => pt.Freelancer)
                .Include(pt => pt.Employer)
                .ToListAsync();
        }
        public async Task<IEnumerable<Proposal>> ListByFreelancerIdAsync(int freelancerId)
        {
            return await _context.Proposals
                .Where(pt => pt.FreelancerId == freelancerId)
                .Include(pt => pt.Freelancer)
                .Include(pt => pt.Employer)
                .ToListAsync();
        }

        public async Task AddAsync(Proposal proposal)
        {
            await _context.Proposals.AddAsync(proposal);
        }

        public void Update(Proposal proposal)
        {
            _context.Proposals.Update(proposal);
        }
        public void Remove(Proposal proposal)
        {
            _context.Proposals.Remove(proposal);
        }

        /*
        public async Task AssignProposal(int employerId, int freelancerId)
        {
            Proposal proposal = await FindByEmployerIdAndFreelancerId(employerId, freelancerId);
            if (proposal == null)
            {
                proposal = new Proposal { EmployerId = employerId, FreelancerId = freelancerId };
                await AddAsync(proposal);
            }
        }

         public async Task<Proposal> FindByEmployerIdAndFreelancerId(int employerId, int freelancerId)
        {
            return await _context.Proposals.FindAsync(employerId, freelancerId);
        }

        public async void UnassignProposal(int employerId, int freelancerId)
        {
            Proposal proposal = await _context.Proposals.FindAsync(employerId, freelancerId);
            if (proposal != null)
                Remove(proposal);
        }
        */







    }
}
