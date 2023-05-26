using DeliveryParcel.Models;

namespace DeliveryParcel.Service.Interfaces
{
    /// <summary>
    /// Интерфейс севриса клиента.
    /// </summary>
    public interface IClientService
    {
        /// <summary>
        /// Получить ID клиента.
        /// </summary>
        /// <param name="clientVm">Модель клиента см. <see cref="ClientVm"/> для получения ID если существует в БД.</param>
        /// <returns>Результат операции <see cref="OperationResponse{TEntity}"/> c ID клиента.</returns>
        Task<OperationResponse<Guid>> GetClientIdAsync(ClientVm clientVm);

        /// <summary>
        /// Создать клиента.
        /// </summary>
        /// <param name="clientVm">Модель клиента см. <see cref="ClientVm"/> для добавления в БД.</param>
        /// <returns>Результат операции <see cref="OperationResponse{TEntity}"/> c ID созданного клиента.</returns>
        Task<OperationResponse<Guid>> CreateClientAsync(ClientVm clientVm);
    }
}