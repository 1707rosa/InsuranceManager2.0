using Microsoft.EntityFrameworkCore;
using Autoinsurance.Domain;
using Autoinsurance.Domain.Entities;
using Autoinsurance.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autoinsurance.Infrastructure.Data;

namespace Autoinsurance.Infrastructure.Repositories
{
    public class ClaimRepository : IClaimRepository
    {
        private readonly AutoinsuranceDbContext _context;

        public ClaimRepository(AutoinsuranceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Claim>> GetAllClaimsAsync()
        {
            return await _context.Claims.ToListAsync();
        }

        public async Task<Claim> GetClaimByIdAsync(int id)
        {
            return await _context.Claims.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddClaimAsync(Claim claim)
        {
            await _context.Claims.AddAsync(claim);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClaimAsync(int id)
        {
            var claim = await _context.Claims.FindAsync(id);
            if (claim != null)
            {
                _context.Claims.Remove(claim);
                await _context.SaveChangesAsync();
            }
        }
    }
}
