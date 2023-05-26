using DeliveryParcel.Models;

namespace DeliveryParcel.Service.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса адреса.
    /// </summary>
    public interface IAddressService
    {
        /// <summary>
        /// Получает идентификатор адреса асинхронно.
        /// </summary>
        /// <param name="addressVm">Модель адреса.</param>
        /// <returns>Ответ операции с идентификатором адреса.</returns>
        Task<OperationResponse<Guid>> GetAddressIdAsync(AddressVm addressVm);

        /// <summary>
        /// Создает адрес асинхронно.
        /// </summary>
        /// <param name="addressVm">Модель адреса.</param>
        /// <returns>Ответ операции с идентификатором созданного адреса.</returns>
        Task<OperationResponse<Guid>> CreateAddressAsync(AddressVm addressVm);
    }
}
