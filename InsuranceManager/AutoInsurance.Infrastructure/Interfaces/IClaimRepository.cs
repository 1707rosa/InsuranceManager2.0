using Autoinsurance.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autoinsurance.Infrastructure.Interfaces
{
    public interface IClaimRepository
    {
        Task<List<Claim>> GetAllClaimsAsync();
        Task<Claim> GetClaimByIdAsync(int id);
        Task AddClaimAsync(Claim claim);
        Task DeleteClaimAsync(int id);
    }
}
