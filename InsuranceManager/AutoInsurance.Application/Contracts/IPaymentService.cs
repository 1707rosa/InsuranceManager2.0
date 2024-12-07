using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoInsurance.Application.Dtos;
namespace AutoInsurance.Application.Contracts
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentDto>> GetAllPaymentsAsync();
        Task<PaymentDto> GetPaymentByIdAsync(int id);
        Task AddPaymentAsync(CreatePaymentDto paymentDto);
        Task UpdatePaymentAsync(int id, UpdatePaymentDto paymentDto);
        Task DeletePaymentAsync(int id);
    }
}
