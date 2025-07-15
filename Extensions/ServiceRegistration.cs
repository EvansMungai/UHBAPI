using UHB.Data;
using UHB.Extensions.RouteHandlers;

namespace UHB.Extensions;

public static class ServiceRegistration
{
    public static void RegisterServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        // Configure Swagger UI
        serviceCollection.ConfigureSwaggerUIDocumentation();

        // Configure DBContext
        serviceCollection.RegisterDataServices(configuration);

        // Configure  Cors
        serviceCollection.ConfigureCors();

        // Configure Application Services
        serviceCollection.RegisterFeatureServices();

        // configure Route Handlers
        serviceCollection.RegisterHandlers();

        // Configure Route registrar
        serviceCollection.RegisterRouteRegistrars();

        // Configure Route Builder
        serviceCollection.AddScoped<RouteHelper>();
    }
}
