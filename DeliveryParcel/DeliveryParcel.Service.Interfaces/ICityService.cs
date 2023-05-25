using DeliveryParcel.Models;

namespace DeliveryParcel.Service.Interfaces
{
    public interface ICityService
    {
        Task<OperationResponse<Guid>> GetCityIdByNameAsync(string cityName);

        Task<OperationResponse<Guid>> CreateCityAsync(string cityName);
    }
}
