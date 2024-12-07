using AutoInsurance.Application.Contracts;
using AutoInsurance.Application.Dtos;
using AutoInsurance.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoInsurance.Application.Services
{
    public class ClaimService : IClaimService
    {
        private readonly List<ClaimDto> _claims = new();

        public async Task<IEnumerable<ClaimDto>> GetAllClaimsAsync()
        {
            return await Task.FromResult(_claims);
        }

        public async Task<ClaimDto> GetClaimByIdAsync(int id)
        {
            var claim = _claims.FirstOrDefault(c => c.Id == id);
            if (claim == null)
                throw new ClaimNotFoundException($"Claim with ID {id} not found.");

            return await Task.FromResult(claim);
        }

        public async Task AddClaimAsync(CreateClaimDto claimDto)
        {
            if (string.IsNullOrWhiteSpace(claimDto.ClaimNumber))
                throw new InvalidEntityDataException("Claim number cannot be empty.");

            var newClaim = new ClaimDto
            {
                Id = _claims.Count + 1,
                ClaimNumber = claimDto.ClaimNumber,
                DateOfClaim = claimDto.DateOfClaim,
                PolicyId = claimDto.PolicyId,
                Description = claimDto.Description
            };
            _claims.Add(newClaim);
            await Task.CompletedTask;
        }

        public async Task UpdateClaimAsync(int id, UpdateClaimDto claimDto)
        {
            var claim = _claims.FirstOrDefault(c => c.Id == id);
            if (claim == null)
                throw new ClaimNotFoundException($"Claim with ID {id} not found.");

            if (!string.IsNullOrWhiteSpace(claimDto.ClaimNumber))
                claim.ClaimNumber = claimDto.ClaimNumber;

            if (claimDto.DateOfClaim.HasValue)
                claim.DateOfClaim = claimDto.DateOfClaim.Value;

            if (claimDto.PolicyId.HasValue)
                claim.PolicyId = claimDto.PolicyId.Value;

            if (!string.IsNullOrWhiteSpace(claimDto.Description))
                claim.Description = claimDto.Description;

            await Task.CompletedTask;
        }

        public async Task DeleteClaimAsync(int id)
        {
            var claim = _claims.FirstOrDefault(c => c.Id == id);
            if (claim == null)
                throw new ClaimNotFoundException($"Claim with ID {id} not found.");

            _claims.Remove(claim);
            await Task.CompletedTask;
        }
    }
}
