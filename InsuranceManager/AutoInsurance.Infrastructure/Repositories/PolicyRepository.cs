using Microsoft.EntityFrameworkCore;
using Autoinsurance.Domain;
using Autoinsurance.Domain.Entities;
using Autoinsurance.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autoinsurance.Infrastructure.Data;

namespace Autoinsurance.Infrastructure.Repositories
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly AutoinsuranceDbContext _context;

        public PolicyRepository(AutoinsuranceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Policy>> GetAllPoliciesAsync()
        {
            return await _context.Policies.ToListAsync();
        }

        public async Task<Policy> GetPolicyByIdAsync(int id)
        {
            return await _context.Policies.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddPolicyAsync(Policy policy)
        {
            await _context.Policies.AddAsync(policy);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePolicyAsync(int id)
        {
            var policy = await _context.Policies.FindAsync(id);
            if (policy != null)
            {
                _context.Policies.Remove(policy);
                await _context.SaveChangesAsync();
            }
        }
    }
}
