using CargoDeliveryWeb.Data.Entities;
using CargoDeliveryWeb.Data.Repositories.Interfaces;

namespace CargoDeliveryWeb.Data.Repositories;

public class OrderRerpository(AppDbContext context) : BaseRepository<Order>(context), IOrderRepository
{}
