using DeliveryParcel.Data;
using DeliveryParcel.Data.Interface;
using DeliveryParcel.Models;
using DeliveryParcel.Service.Interfaces;

namespace DeliveryParcel.Service.Infrastructure
{
    /// <summary>
    /// Сервис для работы с клиентами.
    /// </summary>
    public class ClientService : IClientService
    {
        private readonly IBaseRepository<Client> _clientRepository;

        /// <summary>
        /// Конструктор сервиса клиент.
        /// </summary>
        /// <param name="clientRepository">Репозиторий клиента.</param>
        public ClientService(IBaseRepository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        /// <inheritdoc/>
        public async Task<OperationResponse<Guid>> CreateClientAsync(ClientVm clientVm)
        {
            var client = new Client
            {
                FirstName = clientVm.FirstName,
                LastName = clientVm.LastName,
                MiddleName = clientVm.MiddleName,
                CreatedDate = DateTime.UtcNow,
            };
            await _clientRepository.AddEntityAsync(client);
            return new OperationResponse<Guid> { IsSuccess = true, Result = client.Id };
        }

        /// <inheritdoc/>
        public async Task<OperationResponse<Guid>> GetClientIdAsync(ClientVm clientVm)
        {
            var normFirstName = string.Join(" ", clientVm.FirstName.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries)).ToUpper();
            var normLastName = string.Join(" ", clientVm.LastName.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries)).ToUpper();
            string normMiddleName = string.Empty;
            if (!string.IsNullOrEmpty(clientVm.MiddleName))
                normMiddleName = string.Join(" ", clientVm.MiddleName.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries)).ToUpper();

            var client = await _clientRepository.GetEnttyOrDeafaultAsync(c => c.FirstName.ToUpper() == normFirstName &&
                                                                              c.LastName.ToUpper() == normLastName ||
                                                                              (!string.IsNullOrEmpty(c.MiddleName) &&
                                                                              c.MiddleName.ToUpper() == normMiddleName));
            if (client is null)
                return new OperationResponse<Guid> { IsSuccess = false };

            return new OperationResponse<Guid> { IsSuccess = true, Result = client.Id };
        }
    }
}
