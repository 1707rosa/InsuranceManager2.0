using System.ComponentModel.DataAnnotations;

namespace AutoInsurance.API.Requests
{
    public class UpdatePolicyRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string PolicyNumber { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Premium must be greater than or equal to 0.")]
        public decimal Premium { get; set; }

        public int? VehicleId { get; set; }

        public int? ClientId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
    }
}
