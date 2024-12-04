namespace Autoinsurance.Infrastructure.Modelss
{
    public class VehicleModel
    {
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public string PlateNumber { get; set; } = string.Empty;
        public int CustomersId { get; set; }
    }
}
