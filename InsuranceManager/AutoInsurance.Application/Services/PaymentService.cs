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
    public class PaymentService : IPaymentService
    {
        private readonly List<PaymentDto> _payments = new();

        public async Task<IEnumerable<PaymentDto>> GetAllPaymentsAsync()
        {
            return await Task.FromResult(_payments);
        }

        public async Task<PaymentDto> GetPaymentByIdAsync(int id)
        {
            var payment = _payments.FirstOrDefault(p => p.Id == id);
            if (payment == null)
                throw new PaymentNotFoundException($"Payment with ID {id} not found.");

            return await Task.FromResult(payment);
        }

        public async Task AddPaymentAsync(CreatePaymentDto paymentDto)
        {
            if (paymentDto.Amount <= 0)
                throw new InvalidEntityDataException("Payment amount must be greater than zero.");

            var newPayment = new PaymentDto
            {
                Id = _payments.Count + 1,
                Amount = paymentDto.Amount,
                PaymentDate = paymentDto.PaymentDate,
                PolicyId = paymentDto.PolicyId,
                PaymentMethod = paymentDto.PaymentMethod
            };
            _payments.Add(newPayment);
            await Task.CompletedTask;
        }

        public async Task UpdatePaymentAsync(int id, UpdatePaymentDto paymentDto)
        {
            var payment = _payments.FirstOrDefault(p => p.Id == id);
            if (payment == null)
                throw new PaymentNotFoundException($"Payment with ID {id} not found.");

            if (paymentDto.Amount.HasValue && paymentDto.Amount > 0)
                payment.Amount = paymentDto.Amount.Value;

            if (paymentDto.PaymentDate.HasValue)
                payment.PaymentDate = paymentDto.PaymentDate.Value;

            if (paymentDto.PolicyId.HasValue)
                payment.PolicyId = paymentDto.PolicyId.Value;

            if (!string.IsNullOrWhiteSpace(paymentDto.PaymentMethod))
                payment.PaymentMethod = paymentDto.PaymentMethod;

            await Task.CompletedTask;
        }

        public async Task DeletePaymentAsync(int id)
        {
            var payment = _payments.FirstOrDefault(p => p.Id == id);
            if (payment == null)
                throw new PaymentNotFoundException($"Payment with ID {id} not found.");

            _payments.Remove(payment);
            await Task.CompletedTask;
        }
    }
}
