using DeliveryParcel.Models;

namespace DeliveryParcel.Service.Interfaces
{
    public interface IClientService
    {
        Task<OperationResponse<Guid>> GetClientIdAsync(ClientVm clientVm);

        Task<OperationResponse<Guid>> CreateClientAsync(ClientVm clientVm);
    }
}
