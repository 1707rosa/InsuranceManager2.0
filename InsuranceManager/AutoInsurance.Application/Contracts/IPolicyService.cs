using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoInsurance.Application.Dtos;
namespace AutoInsurance.Application.Contracts
{
    public interface IPolicyService
    {
        Task<IEnumerable<PolicyDto>> GetAllPoliciesAsync();
        Task<PolicyDto> GetPolicyByIdAsync(int id);
        Task AddPolicyAsync(CreatePolicyDto policyDto);
        Task UpdatePolicyAsync(int id, UpdatePolicyDto policyDto);
        Task DeletePolicyAsync(int id);
    }
}
