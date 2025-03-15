using CargoDeliveryWeb.Mappings;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace CargoDeliveryWeb.Configuration;

public static class ServicesConfiguration
{
    public static void ConfigureWeb(this IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssemblyContaining<Program>();

        services.AddAutoMapper(typeof(OrderMapperProfile).Assembly);
    }
}
