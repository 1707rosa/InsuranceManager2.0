using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoInsurance.Application.Dtos
{
    public class PolicyDto
    {
        public int Id { get; set; }
        public string PolicyNumber { get; set; }
        public decimal Premium { get; set; }
        public int VehicleId { get; set; }
        public int ClientId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
