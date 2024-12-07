using System.ComponentModel.DataAnnotations;

namespace AutoInsurance.API.Requests
{
    public class UpdateClaimRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string ClaimNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfClaim { get; set; }

        public int? PolicyId { get; set; }

        public string Description { get; set; }
    }
}
