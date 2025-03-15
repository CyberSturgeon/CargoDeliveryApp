using CargoDeliveryWeb.Business.Models;

namespace CargoDeliveryWeb.Business.Services.Interfaces
{
    public interface IOrderService
    {
        Task AddAsync(OrderModel orderModel);
        Task<List<OrderModel>> GetAllAsync();
        Task<OrderModel> GetByIdAsync(Guid id);
    }
}