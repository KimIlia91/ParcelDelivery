using DeliveryParcel.Data;
using DeliveryParcel.Data.Interface;
using DeliveryParcel.Models;
using DeliveryParcel.Service.Interfaces;

namespace DeliveryParcel.Service.Infrastructure
{
    public class ParcelService : IParcelService
    {
        private readonly IBaseRepository<Parcel> _parcelRepository;

        public ParcelService(IBaseRepository<Parcel> parcelRepository)
        {
            _parcelRepository = parcelRepository;
        }

        public async Task<OperationResponse<Guid>> CreateParcelAsync(ParcelVm parcelVm)
        {
            var parcel = new Parcel { CreatedDate = DateTime.UtcNow, Weight = parcelVm.Wieght };
            await _parcelRepository.AddEntityAsync(parcel);
            return new OperationResponse<Guid> { IsSuccess = true, Result = parcel.Id };
        }
    }
}
