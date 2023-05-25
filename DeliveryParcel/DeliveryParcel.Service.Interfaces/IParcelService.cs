using DeliveryParcel.Models;

namespace DeliveryParcel.Service.Interfaces
{
    public interface IParcelService
    {
        Task<OperationResponse<Guid>> CreateParcelAsync(ParcelVm parcelVm);
    }
}
