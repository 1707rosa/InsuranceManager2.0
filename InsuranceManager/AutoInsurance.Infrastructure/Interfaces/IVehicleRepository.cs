using Autoinsurance.Domain.Entities;


namespace Autoinsurance.Infrastructure.Interfaces
{
    public interface IVehicleRepository
    {
        Task<List<Vehicle>> GetAllVehiclesAsync();
        Task<Vehicle> GetVehicleByIdAsync(int id);
        Task AddVehicleAsync(Vehicle vehicle);
        Task DeleteVehicleAsync(int id);
    }
}

