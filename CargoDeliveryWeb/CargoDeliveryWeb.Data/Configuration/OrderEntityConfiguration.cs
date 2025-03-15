using CargoDeliveryWeb.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CargoDeliveryWeb.Data.Configuration;

internal static class OrderEntityConfiguration
{
    internal static void ConfigureOrder(this ModelBuilder builder)
    {
        builder.Entity<Order>(entity =>
        {
            entity.HasKey( o => o.Id);  

            entity.Property(o => o.SenderCity)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(o => o.SenderAddress)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(o => o.ReceiverCity)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(o => o.ReceiverAddress)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(o => o.Weight)
                .HasPrecision(10, 2)
                .IsRequired();

            entity.Property(o => o.PickupDate)
                .HasColumnType("date")
                .IsRequired();

            entity.HasIndex(o => o.OrderNumber)
                .IsUnique();

            entity.Property(o => o.OrderNumber)
                    .HasDefaultValueSql("substr(uuid_generate_v4()::text, 1, 8)")
                    .IsRequired();
        });
    }
}