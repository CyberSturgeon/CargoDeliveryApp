using AutoMapper;
using CargoDeliveryWeb.Business.Exceptions;
using CargoDeliveryWeb.Business.Models;
using CargoDeliveryWeb.Business.Services.Interfaces;
using CargoDeliveryWeb.Data.Entities;
using CargoDeliveryWeb.Data.Repositories.Interfaces;

namespace CargoDeliveryWeb.Business.Services;

public class OrderService(IOrderRepository orderRepository, IMapper mapper) : IOrderService
{
    public async Task AddAsync(OrderModel orderModel)
    {
        await orderRepository.AddAsync(mapper.Map<Order>(orderModel));
    }

    public async Task<OrderModel> GetByIdAsync(Guid id) =>
        mapper.Map<OrderModel>(await orderRepository.GetByIdAsync(id)) ?? throw new EntityNotFoundException($"Order {id} not found");

    public async Task<List<OrderModel>> GetAllAsync() =>
        mapper.Map<List<OrderModel>>(await orderRepository.GetAllAsync());
}
