

using System.ComponentModel.DataAnnotations.Schema;

namespace Autoinsurance.Domain.Entities
{
    public class Policy
    {
        public int Id { get; set; }
        public string PolicyNumber { get; set; } = string.Empty;
        public decimal CoverageAmount { get; set; }
        public decimal PremiumAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("CustomersId")]
        public int CustomersId { get; set; }

        [ForeignKey("CustomersId")]
        public Customer? Customer { get; set; }

        public int VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }

        public ICollection<Claim> Claims { get; set; } = new List<Claim>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
