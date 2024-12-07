using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoInsurance.Application.Dtos
{
    public class UpdatePaymentDto
    {
        [Range(0, double.MaxValue)]
        public decimal? Amount { get; set; }

        public DateTime? PaymentDate { get; set; }

        public int? PolicyId { get; set; }

        [StringLength(50)]
        public string PaymentMethod { get; set; }
    }
}
