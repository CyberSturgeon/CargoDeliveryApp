using CargoDeliveryWeb.Data.Configuration;
using CargoDeliveryWeb.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CargoDeliveryWeb.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Order> Orders { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureOrder();
    }
}
