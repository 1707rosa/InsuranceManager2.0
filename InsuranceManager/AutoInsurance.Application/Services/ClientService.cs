using AutoInsurance.Application.Contracts;
using AutoInsurance.Application.Exceptions;
using AutoInsurance.Application.Dtos;

namespace AutoInsurance.Application.Services

{
    public class ClientService : IClientService
    {
        private readonly List<ClientDto> _clients = new();

        public async Task<IEnumerable<ClientDto>> GetAllClientsAsync()
        {
            return await Task.FromResult(_clients);
        }

        public async Task<ClientDto> GetClientByIdAsync(int id)
        {
            var client = _clients.FirstOrDefault(c => c.Id == id);
            if (client == null)
                throw new ClientNotFoundException($"Client with ID {id} not found.");

            return await Task.FromResult(client);
        }

        public async Task AddClientAsync(CreateClientDto clientDto)
        {
            if (string.IsNullOrWhiteSpace(clientDto.FullName))
                throw new ArgumentException("Client name cannot be empty.");

            var newClient = new ClientDto
            {
                Id = _clients.Count + 1,
                FullName = clientDto.FullName,
                Email = clientDto.Email,
                PhoneNumber = clientDto.PhoneNumber
            };
            _clients.Add(newClient);
            await Task.CompletedTask;
        }

        public async Task UpdateClientAsync(int id, UpdateClientDto clientDto)
        {
            var client = _clients.FirstOrDefault(c => c.Id == id);
            if (client == null)
                throw new ClientNotFoundException($"Client with ID {id} not found.");

            if (!string.IsNullOrWhiteSpace(clientDto.FullName))
                client.FullName = clientDto.FullName;

            if (!string.IsNullOrWhiteSpace(clientDto.Email))
                client.Email = clientDto.Email;

            if (!string.IsNullOrWhiteSpace(clientDto.PhoneNumber))
                client.PhoneNumber = clientDto.PhoneNumber;

            await Task.CompletedTask;
        }

        public async Task DeleteClientAsync(int id)
        {
            var client = _clients.FirstOrDefault(c => c.Id == id);
            if (client == null)
                throw new ClientNotFoundException($"Client with ID {id} not found.");

            _clients.Remove(client);
            await Task.CompletedTask;
        }
    }
}
