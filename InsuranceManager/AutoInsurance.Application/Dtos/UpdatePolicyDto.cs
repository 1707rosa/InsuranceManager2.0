using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoInsurance.Application.Dtos
{
    public class UpdatePolicyDto
    {
        [StringLength(50)]
        public string PolicyNumber { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Premium { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
