using DeliveryParcel.Data;
using DeliveryParcel.Data.Interface;
using DeliveryParcel.Models;
using DeliveryParcel.Service.Interfaces;

namespace DeliveryParcel.Service.Infrastructure
{
    public class AddressService : IAddressService
    {
        private readonly IBaseRepository<Address> _addressRepository;
        private readonly ICityService _cityService;

        public AddressService(IBaseRepository<Address> addressRepository, ICityService cityService)
        {
            _addressRepository = addressRepository;
            _cityService = cityService;
        }

        public async Task<OperationResponse<Guid>> CreateAddressAsync(AddressVm addressVm)
        {
            var operationResponse = await _cityService.GetCityIdByNameAsync(addressVm.CityName);
            if (!operationResponse.IsSuccess)
                operationResponse = await _cityService.CreateCityAsync(addressVm.CityName);

            var address = new Address
            {
                CityId = operationResponse.Result,
                Street = addressVm.Street,
                House = addressVm.House,
                Flat = addressVm.Flat,
                Appartament = addressVm.Appartament,
                CreatedDate = DateTime.UtcNow
            };
            await _addressRepository.AddEntityAsync(address);
            return new OperationResponse<Guid> { IsSuccess = true, Result = address.Id };
        }

        public async Task<OperationResponse<Guid>> GetAddressIdAsync(AddressVm addressVm)
        {
            var cityName = string.Join(" ", addressVm.CityName.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries)).ToUpper();
            var street = string.Join(" ", addressVm.Street.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries)).ToUpper();
            var house = new string(addressVm.House.Where(c => !char.IsWhiteSpace(c)).ToArray()).ToUpper();
            var appartament = string.Empty;
            if (!string.IsNullOrEmpty(addressVm.Appartament))
                appartament = new string(addressVm.House.Where(c => !char.IsWhiteSpace(c)).ToArray()).ToUpper();

            var address = await _addressRepository.GetEnttyOrDeafaultAsync(a => a.City.Name.ToUpper() == cityName &&                                                                
                                                                                a.Street.ToUpper() == street &&                                                           
                                                                                a.House.ToUpper() == house &&                                                                
                                                                                a.Flat == addressVm.Flat ||
                                                                                (!string.IsNullOrEmpty(a.Appartament) &&
                                                                                a.Appartament.ToUpper() == appartament),
                                                                                includeProperties: "City");
            if (address is null)
                return new OperationResponse<Guid> { IsSuccess = false };

            return new OperationResponse<Guid> { IsSuccess =  true, Result = address.Id };
        }
    }
}
