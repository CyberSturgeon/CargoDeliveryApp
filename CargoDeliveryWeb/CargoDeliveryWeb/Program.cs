using CargoDeliveryWeb.Data.Configuration;
using CargoDeliveryWeb.Business.Configuration;
using CargoDeliveryWeb.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
            .AddJsonFile("appsettings.secrets.json", optional: true, reloadOnChange: true)
            .AddCommandLine(args)
            .AddEnvironmentVariables()
            .Build();

builder.Services.ConfigureWeb();

var configuration = builder.Configuration;

builder.Services.ConfigureBusiness(configuration);
builder.Services.ConfigureData(configuration);

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Orders}/{action=Index}/{id?}");

app.Run();
