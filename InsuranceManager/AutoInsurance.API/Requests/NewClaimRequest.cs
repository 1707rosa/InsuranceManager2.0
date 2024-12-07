using System.ComponentModel.DataAnnotations;

namespace AutoInsurance.API.Requests
{
    public class NewClaimRequest
    {
        [Required]
        public string ClaimNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfClaim { get; set; }

        [Required]
        public int PolicyId { get; set; }

        public string Description { get; set; }
    }
}
