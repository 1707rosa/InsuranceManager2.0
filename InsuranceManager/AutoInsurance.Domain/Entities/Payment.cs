namespace Autoinsurance.Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;


        public int PolicyId { get; set; }
        public Policy? Policy { get; set; }
    }
}
