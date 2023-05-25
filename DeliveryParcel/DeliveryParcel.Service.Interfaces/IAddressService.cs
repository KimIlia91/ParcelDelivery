using DeliveryParcel.Models;

namespace DeliveryParcel.Service.Interfaces
{
    public interface IAddressService
    {
        Task<OperationResponse<Guid>> GetAddressIdAsync(AddressVm addressVm);

        Task<OperationResponse<Guid>> CreateAddressAsync(AddressVm addressVm);
    }
}
