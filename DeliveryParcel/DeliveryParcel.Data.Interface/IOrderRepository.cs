namespace DeliveryParcel.Data.Interface
{
    /// <summary>
    /// Интерфейс репозитория заказов.
    /// </summary>
    public interface IOrderRepository : IBaseRepository<Order>
    {
        /// <summary>
        /// Асинхронно получает все заказы.
        /// </summary>
        /// <returns>Коллекция заказов.</returns>
        Task<IEnumerable<Order>> GetAllOrdersAsync();
    }
}