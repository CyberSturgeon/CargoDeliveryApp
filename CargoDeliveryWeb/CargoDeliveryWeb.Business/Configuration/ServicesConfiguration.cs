using CargoDeliveryWeb.Business.Mappings;
using CargoDeliveryWeb.Business.Services;
using CargoDeliveryWeb.Business.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CargoDeliveryWeb.Business.Configuration;

public static class ServicesConfiguration
{
    public static void ConfigureBusiness(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IOrderService, OrderService>();
        services.AddAutoMapper(typeof(OrderMapperProfile).Assembly);
    }
}
