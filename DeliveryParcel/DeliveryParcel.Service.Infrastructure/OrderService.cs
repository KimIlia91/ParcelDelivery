using AutoMapper;
using DeliveryParcel.Data;
using DeliveryParcel.Data.Interface;
using DeliveryParcel.Models;
using DeliveryParcel.Service.Interfaces;

namespace DeliveryParcel.Service.Infrastructure
{
    /// <summary>
    /// Сервис для работы с заказами.
    /// </summary>
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IClientService _clientService;
        private readonly IAddressService _addressService;
        private readonly IParcelService _parcelService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор сервиса.
        /// </summary>
        /// <param name="orderRepository">Репозиторий заказа.</param>
        /// <param name="clientService">Репозиторий клиента.</param>
        /// <param name="addressService">Репозиторий адреса.</param>
        /// <param name="parcelService">Репозиторий послыки.</param>
        /// <param name="mapper">Маппер</param>
        public OrderService(
            IOrderRepository orderRepository, 
            IClientService clientService, 
            IAddressService addressService, 
            IParcelService parcelService,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _clientService = clientService;
            _addressService = addressService;
            _parcelService = parcelService; 
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<OperationResponse<IEnumerable<OrderVm>>> GetAllOrdesAsync()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();
            var orderVms = _mapper.Map<IEnumerable<OrderVm>>(orders);   
            return new OperationResponse<IEnumerable<OrderVm>> { IsSuccess = true, Result =  orderVms };
        }

        /// <inheritdoc/>
        public async Task<OperationResponse<Guid>> MakeOrderAsync(OrderCreateVm orderVm)
        {
            var senderAddressResponse = await _addressService.GetAddressIdAsync(orderVm.SenderAddress);
            if (!senderAddressResponse.IsSuccess)
                senderAddressResponse = await _addressService.CreateAddressAsync(orderVm.SenderAddress);

            var senderResponse = await _clientService.GetClientIdAsync(orderVm.Sender);
            if (!senderResponse.IsSuccess)
                senderResponse = await _clientService.CreateClientAsync(orderVm.Sender);

            var recipientAddressResponse = await _addressService.GetAddressIdAsync(orderVm.RecipientAddress);
            if (!recipientAddressResponse.IsSuccess)
                recipientAddressResponse = await _addressService.CreateAddressAsync(orderVm.RecipientAddress);

            var recipientResponse = await _clientService.GetClientIdAsync(orderVm.Recipient);
            if (!recipientResponse.IsSuccess)
                recipientResponse = await _clientService.CreateClientAsync(orderVm.Recipient);

            var parcelResponse = await _parcelService.CreateParcelAsync(orderVm.Parcel);
            var order = new Order
            {
                SenderId = senderResponse.Result,
                RecipientId = recipientResponse.Result,
                SenderAddressId = senderAddressResponse.Result,
                RecipientAddressId = recipientAddressResponse.Result,
                ParcelId = parcelResponse.Result,
                ShippingDate = orderVm.ShippingDate,
                CreatedDate = DateTime.UtcNow
            };
            await _orderRepository.AddEntityAsync(order);
            return new OperationResponse<Guid> { IsSuccess = true, Result = order.Id };
        }
    }
}
