using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoInsurance.Application.Dtos
{
    public class UpdateClaimDto
    {
        [StringLength(50)]
        public string ClaimNumber { get; set; }

        public DateTime? DateOfClaim { get; set; }

        public int? PolicyId { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }
    }
}
