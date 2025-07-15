using Microsoft.EntityFrameworkCore;
using UHB.Data.Infrastructure;

namespace UHB.Data;

public static class ServiceRegistration
{
    public static void RegisterDataServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("UHB");
        serviceCollection.AddDbContext<UhbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    }
}
