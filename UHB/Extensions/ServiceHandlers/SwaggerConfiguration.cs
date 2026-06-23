using Microsoft.OpenApi.Models;

namespace UHB.Extensions;

public static class SwaggerConfiguration
{
    public static void ConfigureSwaggerUIDocumentation(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddEndpointsApiExplorer();
        serviceCollection.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "UHB API", Description = "Making university hostel booking process a seamless easy process", Version = "v1" });
        });
    }
}
