using Autoinsurance.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autoinsurance.Infrastructure.Interfaces
{
    public interface IPaymentRepository
    {
        Task<List<Payment>> GetAllPaymentsAsync();
        Task<Payment> GetPaymentByIdAsync(int id);
        Task AddPaymentAsync(Payment payment);
        Task DeletePaymentAsync(int id);
    }
}
