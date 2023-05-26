using DeliveryParcel.Models;

namespace DeliveryParcel.Service.Interfaces
{
    /// <summary>
    /// Интерфейс послыки.
    /// </summary>
    public interface IParcelService
    {
        /// <summary>
        /// Создать посылку.
        /// </summary>
        /// <param name="parcelVm">Модель для создания послыки см. <see cref="ParcelVm"/>.</param>
        /// <returns>Результат операции <see cref="OperationResponse{TEntity}"/> с ID созданной посылки.</returns>
        Task<OperationResponse<Guid>> CreateParcelAsync(ParcelVm parcelVm);
    }
}
