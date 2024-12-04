namespace Autoinsurance.Infrastructure.Modelss
{
    public class PolicyModel
    {
        public string PolicyNumber { get; set; } = string.Empty;
        public int CustomersId { get; set; }
        public int VehicleId { get; set; }
        public decimal CoverageAmount { get; set; }
        public decimal PremiumAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

