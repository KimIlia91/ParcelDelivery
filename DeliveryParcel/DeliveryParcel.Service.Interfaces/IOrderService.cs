using DeliveryParcel.Models;

namespace DeliveryParcel.Service.Interfaces
{
    /// <summary>
    /// Интерфейс заказа.
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Добавить заказ.
        /// </summary>
        /// <param name="orderVm">Модель для создания заказа <see cref="OrderCreateVm"/>.</param>
        /// <returns>Результат операции <see cref="OperationResponse{TEntity}"/> c ID созданного заказа.</returns>
        Task<OperationResponse<Guid>> MakeOrderAsync(OrderCreateVm orderVm);

        /// <summary>
        /// Получить список всех заказов.
        /// </summary>
        /// <returns>Результат операции <see cref="OperationResponse{TEntity}"/> c со списком моделей заказов см. <see cref="OrderVm"/>.</returns>
        Task<OperationResponse<IEnumerable<OrderVm>>> GetAllOrdesAsync();
    }
}
