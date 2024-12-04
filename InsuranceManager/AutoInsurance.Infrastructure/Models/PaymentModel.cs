namespace Autoinsurance.Infrastructure.Models
{
    public class PaymentModel
    {
        public decimal Amount { get; set; }
        public int PolicyId { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
    }
}
