using AutoInsurance.Application.Contracts;
using AutoInsurance.Application.Dtos;
using AutoInsurance.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoInsurance.Application.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly List<VehicleDto> _vehicles = new();

        public async Task<IEnumerable<VehicleDto>> GetAllVehiclesAsync()
        {
            return await Task.FromResult(_vehicles);
        }

        public async Task<VehicleDto> GetVehicleByIdAsync(int id)
        {
            var vehicle = _vehicles.FirstOrDefault(v => v.Id == id);
            if (vehicle == null)
                throw new VehicleNotFoundException($"Vehicle with ID {id} not found.");

            return await Task.FromResult(vehicle);
        }

        public async Task AddVehicleAsync(CreateVehicleDto vehicleDto)
        {
            if (string.IsNullOrWhiteSpace(vehicleDto.LicensePlate))
                throw new InvalidEntityDataException("License plate cannot be empty.");

            var newVehicle = new VehicleDto
            {
                Id = _vehicles.Count + 1,
                LicensePlate = vehicleDto.LicensePlate,
                Model = vehicleDto.Model,
                Year = vehicleDto.Year,
                Make = vehicleDto.Make
            };
            _vehicles.Add(newVehicle);
            await Task.CompletedTask;
        }

        public async Task UpdateVehicleAsync(int id, UpdateVehicleDto vehicleDto)
        {
            var vehicle = _vehicles.FirstOrDefault(v => v.Id == id);
            if (vehicle == null)
                throw new VehicleNotFoundException($"Vehicle with ID {id} not found.");

            if (!string.IsNullOrWhiteSpace(vehicleDto.LicensePlate))
                vehicle.LicensePlate = vehicleDto.LicensePlate;

            if (!string.IsNullOrWhiteSpace(vehicleDto.Model))
                vehicle.Model = vehicleDto.Model;

            if (vehicleDto.Year.HasValue)
                vehicle.Year = vehicleDto.Year.Value;

            if (!string.IsNullOrWhiteSpace(vehicleDto.Make))
                vehicle.Make = vehicleDto.Make;

            await Task.CompletedTask;
        }

        public async Task DeleteVehicleAsync(int id)
        {
            var vehicle = _vehicles.FirstOrDefault(v => v.Id == id);
            if (vehicle == null)
                throw new VehicleNotFoundException($"Vehicle with ID {id} not found.");

            _vehicles.Remove(vehicle);
            await Task.CompletedTask;
        }
    }
}
