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
    public class PolicyService : IPolicyService
    {
        private readonly List<PolicyDto> _policies = new();

        public async Task<IEnumerable<PolicyDto>> GetAllPoliciesAsync()
        {
            return await Task.FromResult(_policies);
        }

        public async Task<PolicyDto> GetPolicyByIdAsync(int id)
        {
            var policy = _policies.FirstOrDefault(p => p.Id == id);
            if (policy == null)
                throw new PolicyNotFoundException($"Policy with ID {id} not found.");

            return await Task.FromResult(policy);
        }

        public async Task AddPolicyAsync(CreatePolicyDto policyDto)
        {
            if (string.IsNullOrWhiteSpace(policyDto.PolicyNumber))
                throw new InvalidEntityDataException("Policy number cannot be empty.");

            var newPolicy = new PolicyDto
            {
                Id = _policies.Count + 1,
                PolicyNumber = policyDto.PolicyNumber,
                Premium = policyDto.Premium,
                VehicleId = policyDto.VehicleId,
                ClientId = policyDto.ClientId,
                StartDate = policyDto.StartDate,
                EndDate = policyDto.EndDate
            };
            _policies.Add(newPolicy);
            await Task.CompletedTask;
        }

        public async Task UpdatePolicyAsync(int id, UpdatePolicyDto policyDto)
        {
            var policy = _policies.FirstOrDefault(p => p.Id == id);
            if (policy == null)
                throw new PolicyNotFoundException($"Policy with ID {id} not found.");

            if (!string.IsNullOrWhiteSpace(policyDto.PolicyNumber))
                policy.PolicyNumber = policyDto.PolicyNumber;

            if (policyDto.Premium >= 0)
                policy.Premium = policyDto.Premium;

            if (policyDto.StartDate.HasValue)
                policy.StartDate = policyDto.StartDate.Value;

            if (policyDto.EndDate.HasValue)
                policy.EndDate = policyDto.EndDate.Value;

            await Task.CompletedTask;
        }

        public async Task DeletePolicyAsync(int id)
        {
            var policy = _policies.FirstOrDefault(p => p.Id == id);
            if (policy == null)
                throw new PolicyNotFoundException($"Policy with ID {id} not found.");

            _policies.Remove(policy);
            await Task.CompletedTask;
        }
    }
}
