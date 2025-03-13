using CargoDeliveryWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CargoDeliveryWeb.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Order> Orders { get; set; }
}
