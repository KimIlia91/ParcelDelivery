using DeliveryParcel.Data;
using DeliveryParcel.Data.Interface;
using DeliveryParcel.Models;
using DeliveryParcel.Service.Interfaces;

namespace DeliveryParcel.Service.Infrastructure
{
    /// <summary>
    /// Сервис для роботы с посылками.
    /// </summary>
    public class ParcelService : IParcelService
    {
        private readonly IBaseRepository<Parcel> _parcelRepository;

        /// <summary>
        /// Конструктор сервиса.
        /// </summary>
        /// <param name="parcelRepository">Репозиторий посылки.</param>
        public ParcelService(IBaseRepository<Parcel> parcelRepository)
        {
            _parcelRepository = parcelRepository;
        }

        /// <inheritdoc/>
        public async Task<OperationResponse<Guid>> CreateParcelAsync(ParcelVm parcelVm)
        {
            var parcel = new Parcel { CreatedDate = DateTime.UtcNow, Weight = parcelVm.Wieght };
            await _parcelRepository.AddEntityAsync(parcel);
            return new OperationResponse<Guid> { IsSuccess = true, Result = parcel.Id };
        }
    }
}
