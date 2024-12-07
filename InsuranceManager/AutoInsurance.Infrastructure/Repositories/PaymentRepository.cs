using Autoinsurance.Domain.Entities;
using Autoinsurance.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Autoinsurance.Infrastructure.Interfaces;

namespace Autoinsurance.Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AutoinsuranceDbContext _context;

        public PaymentRepository(AutoinsuranceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Payment>> GetAllPaymentsAsync()
        {
            return await _context.Payments.ToListAsync();
        }

        public async Task<Payment> GetPaymentByIdAsync(int id)
        {
            return await _context.Payments.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddPaymentAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePaymentAsync(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
