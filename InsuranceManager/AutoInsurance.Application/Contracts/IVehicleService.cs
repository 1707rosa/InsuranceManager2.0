using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoInsurance.Application.Dtos;
namespace AutoInsurance.Application.Contracts
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleDto>> GetAllVehiclesAsync();
        Task<VehicleDto> GetVehicleByIdAsync(int id);
        Task AddVehicleAsync(CreateVehicleDto vehicleDto);
        Task UpdateVehicleAsync(int id, UpdateVehicleDto vehicleDto);
        Task DeleteVehicleAsync(int id);
    }
}
