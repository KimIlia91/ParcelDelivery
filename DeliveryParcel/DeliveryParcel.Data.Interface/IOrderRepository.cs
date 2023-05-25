namespace DeliveryParcel.Data.Interface
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
    }
}
