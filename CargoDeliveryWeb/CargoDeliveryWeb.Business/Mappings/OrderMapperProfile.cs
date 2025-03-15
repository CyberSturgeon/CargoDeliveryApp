using AutoMapper;
using CargoDeliveryWeb.Business.Models;
using CargoDeliveryWeb.Data.Entities;

namespace CargoDeliveryWeb.Business.Mappings;

public class OrderMapperProfile : Profile
{
    public OrderMapperProfile()
    {
        CreateMap<OrderModel, Order>().ReverseMap();
    }
}
