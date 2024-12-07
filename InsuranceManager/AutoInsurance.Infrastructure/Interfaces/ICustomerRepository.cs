using Autoinsurance.Domain.Entities;

namespace Autoinsurance.Infrastructure.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task AddCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int id);
    }
}
