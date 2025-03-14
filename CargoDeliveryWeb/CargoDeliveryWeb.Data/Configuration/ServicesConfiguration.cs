using CargoDeliveryWeb.Data.Repositories;
using CargoDeliveryWeb.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CargoDeliveryWeb.Data.Configuration;

public static class ServicesConfiguration
{
    public static void ConfigureData(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IOrderRepository, OrderRerpository>();
    }
}
