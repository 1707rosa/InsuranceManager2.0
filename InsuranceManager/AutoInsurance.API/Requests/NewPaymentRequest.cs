using System.ComponentModel.DataAnnotations;

namespace AutoInsurance.API.Requests
{
    public class NewPaymentRequest
    {
        [Required]
        public decimal Amount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }

        [Required]
        public int PolicyId { get; set; }

        [Required]
        public string PaymentMethod { get; set; }
    }
}
