using CargoDeliveryWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CargoDeliveryWeb.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Order> Orders { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(x => x.Property(y => y.PickupDate).HasColumnType("date"));
    }
}
