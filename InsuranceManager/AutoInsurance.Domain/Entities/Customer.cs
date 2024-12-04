
namespace Autoinsurance.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        
        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        public ICollection<Policy> Policies { get; set; } = new List<Policy>();
    }
}
