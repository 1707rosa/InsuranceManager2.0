

namespace Autoinsurance.Domain.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public string PlateNumber { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        
        public int CustomersId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Policy> Policies { get; set; } = new List<Policy>();
    }
}
