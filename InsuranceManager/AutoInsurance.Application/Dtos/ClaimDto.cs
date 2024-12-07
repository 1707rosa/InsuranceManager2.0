using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoInsurance.Application.Dtos
{
    public class ClaimDto
    {
        public int Id { get; set; }
        public string ClaimNumber { get; set; }
        public DateTime DateOfClaim { get; set; }
        public int PolicyId { get; set; }
        public string Description { get; set; }
    }
}
