using System.ComponentModel.DataAnnotations;

namespace AutoInsurance.API.Requests
{
    public class UpdateVehicleRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string LicensePlate { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Make { get; set; }

        [Range(1900, 2100, ErrorMessage = "Year must be between 1900 and 2100.")]
        public int? Year { get; set; }
    }
}
