using System.ComponentModel.DataAnnotations;

namespace AutoInsurance.API.Requests
{
    public class UpdatePaymentRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }

        public int? PolicyId { get; set; }

        public string PaymentMethod { get; set; }
    }
}
