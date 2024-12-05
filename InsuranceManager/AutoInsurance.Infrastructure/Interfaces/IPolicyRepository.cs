using Autoinsurance.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autoinsurance.Infrastructure.Interfaces
{
    public interface IPolicyRepository
    {
        Task<List<Policy>> GetAllPoliciesAsync();
        Task<Policy> GetPolicyByIdAsync(int id);
        Task AddPolicyAsync(Policy policy);
        Task DeletePolicyAsync(int id);
    }
}
