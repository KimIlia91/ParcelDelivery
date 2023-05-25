using AutoMapper;
using DeliveryParcel.Data;
using DeliveryParcel.Models;

namespace DeliveryParcel.Service.Infrastructure.MapperConfiguration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Order, OrderVm>()
                .ConvertUsing<OrderConverter>();
        }
    }
}
