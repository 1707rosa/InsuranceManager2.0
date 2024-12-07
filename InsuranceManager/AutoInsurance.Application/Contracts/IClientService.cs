using AutoInsurance.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoInsurance.Application.Contracts
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDto>> GetAllClientsAsync();
        Task<ClientDto> GetClientByIdAsync(int id);
        Task AddClientAsync(CreateClientDto clientDto);
        Task UpdateClientAsync(int id, UpdateClientDto clientDto);
        Task DeleteClientAsync(int id);
    }
}
