using UHB.Extensions.RouteHandlers;
using UHB.Extensions.ServiceHandlers;
using UHB.Infrastructure;

namespace UHB.Extensions;

public static class ServiceRegistration
{
    public static void RegisterServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        // Configure Swagger UI
        serviceCollection.ConfigureSwaggerUIDocumentation();

        // Configure AutoMapper Profiles
        serviceCollection.ConfigureMappingProfiles();

        // Configure DBContext
        serviceCollection.RegisterInfrastructureServices(configuration);

        // Configure authentication and authorization services;
        serviceCollection.ConfigureAuthenticationServices();

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
