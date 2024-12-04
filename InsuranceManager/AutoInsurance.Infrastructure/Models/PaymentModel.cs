namespace Autoinsurance.Infrastructure.Modelss
{
    public class PaymentModel
    {
        public decimal Amount { get; set; }
        public int PolicyId { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
    }
}
