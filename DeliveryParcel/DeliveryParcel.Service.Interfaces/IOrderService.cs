using DeliveryParcel.Models;

namespace DeliveryParcel.Service.Interfaces
{
    public interface IOrderService
    {
        Task<OperationResponse<OrderCreateVm>> MakeOrderAsync(OrderCreateVm orderVm);

        Task<OperationResponse<IEnumerable<OrderVm>>> GetAllOrdesAsync();
    }
}
