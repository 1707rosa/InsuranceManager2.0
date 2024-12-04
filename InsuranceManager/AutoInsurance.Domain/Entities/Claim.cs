namespace Autoinsurance.Domain.Entities
{
    public class Claim
    {
        public int Id { get; set; }
        public string ClaimNumber { get; set; } = string.Empty;
        public decimal ClaimAmount { get; set; }
        public DateTime ClaimDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int PolicyId { get; set; }
        public Policy Policy { get; set; }
    }
}
