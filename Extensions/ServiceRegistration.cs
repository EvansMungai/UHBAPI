using UHB.Data;

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
    }
}
