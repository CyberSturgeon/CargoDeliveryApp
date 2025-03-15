using AutoMapper;
using CargoDeliveryWeb.Business.Models;
using CargoDeliveryWeb.Models;

namespace CargoDeliveryWeb.Mappings;

public class OrderMapperProfile : Profile
{
    public OrderMapperProfile()
    {
        CreateMap<OrderRequest, OrderModel>();
        CreateMap<OrderModel, OrderResponse>();
    }
}
