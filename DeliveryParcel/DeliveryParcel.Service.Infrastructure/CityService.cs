using DeliveryParcel.Data;
using DeliveryParcel.Data.Interface;
using DeliveryParcel.Models;
using DeliveryParcel.Service.Interfaces;
using Microsoft.Extensions.Logging;

namespace DeliveryParcel.Service.Infrastructure
{
    public class CityService : ICityService
    {
        private readonly IBaseRepository<City> _cityRepository;

        public CityService(IBaseRepository<City> cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<OperationResponse<Guid>> CreateCityAsync(string cityName)
        {
            if (string.IsNullOrWhiteSpace(cityName) || string.IsNullOrEmpty(cityName))
                return new OperationResponse<Guid> { IsSuccess = false, Errors = $"Строка пустая {nameof(cityName)}" };

            var trimmedCityName = cityName.Trim();
            var cleanedCityName = string.Join(" ", trimmedCityName.Split(' ', StringSplitOptions.RemoveEmptyEntries));
            var city = await _cityRepository.GetEnttyOrDeafaultAsync(c => c.Name.ToUpper() == cleanedCityName.ToUpper());
            if (city is not null)
                return new OperationResponse<Guid> { IsSuccess = false, Errors = "Уже город существует." };

            city = new City { Name = cleanedCityName, CreatedDate = DateTime.UtcNow };
            await _cityRepository.AddEntityAsync(city);
            return new OperationResponse<Guid> { IsSuccess = true, Result = city.Id };
        }

        public async Task<OperationResponse<Guid>> GetCityIdByNameAsync(string cityName)
        {
            var trimmedCityName = cityName.Trim();
            var cleanedCityName = string.Join(" ", trimmedCityName.Split(' ', StringSplitOptions.RemoveEmptyEntries));
            var city = await _cityRepository.GetEnttyOrDeafaultAsync(c => c.Name.ToUpper() == cleanedCityName.ToUpper());
            if (city is null)
                return new OperationResponse<Guid> { IsSuccess = false };

            return new OperationResponse<Guid> { IsSuccess = true, Result = city.Id };
        }
    }
}
