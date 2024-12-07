using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoInsurance.Application.Dtos;

namespace AutoInsurance.Application.Contracts
{
    public interface IClaimService
    {
        Task<IEnumerable<ClaimDto>> GetAllClaimsAsync();
        Task<ClaimDto> GetClaimByIdAsync(int id);
        Task AddClaimAsync(CreateClaimDto claimDto);
        Task UpdateClaimAsync(int id, UpdateClaimDto claimDto);
        Task DeleteClaimAsync(int id);
    }
}
