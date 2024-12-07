using Autoinsurance.Domain.Entities;
using Autoinsurance.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Autoinsurance.Infrastructure.Interfaces;

namespace Autoinsurance.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AutoinsuranceDbContext _context;

        public CustomerRepository(AutoinsuranceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
