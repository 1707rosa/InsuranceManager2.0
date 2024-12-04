namespace Autoinsurance.Infrastructure.Modelss
{
    public class ClaimModel
    {
        public string ClaimNumber { get; set; } = string.Empty;
        public int PolicyId { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime ClaimDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
