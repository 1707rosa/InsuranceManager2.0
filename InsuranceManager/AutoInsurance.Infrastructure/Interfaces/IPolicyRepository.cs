using Autoinsurance.Domain.Entities;

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
