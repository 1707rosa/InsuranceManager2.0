using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoInsurance.Application.Dtos
{
    public class CreatePolicyDto
    {
        [Required]
        [StringLength(50)]
        public string PolicyNumber { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Premium { get; set; }

        [Required]
        public int VehicleId { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
