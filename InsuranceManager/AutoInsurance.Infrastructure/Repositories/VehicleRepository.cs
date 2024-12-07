using Autoinsurance.Domain.Entities;
using Autoinsurance.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Autoinsurance.Infrastructure.Interfaces;
namespace Autoinsurance.Infrastructure.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly AutoinsuranceDbContext _context;

        public VehicleRepository(AutoinsuranceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Vehicle>> GetAllVehiclesAsync()
        {
            return await _context.Vehicles.ToListAsync();
        }

        public async Task<Vehicle> GetVehicleByIdAsync(int id)
        {
            return await _context.Vehicles.FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task AddVehicleAsync(Vehicle vehicle)
        {
            await _context.Vehicles.AddAsync(vehicle);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVehicleAsync(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
                await _context.SaveChangesAsync();
            }
        }
    }
}
