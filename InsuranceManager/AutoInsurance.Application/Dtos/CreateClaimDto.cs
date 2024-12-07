using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoInsurance.Application.Dtos
{
    public class CreateClaimDto
    {
        [Required]
        [StringLength(50)]
        public string ClaimNumber { get; set; }

        [Required]
        public DateTime DateOfClaim { get; set; }

        [Required]
        public int PolicyId { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
    }
}
