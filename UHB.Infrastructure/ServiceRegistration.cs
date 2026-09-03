using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UHB.Application.Interface;
using UHB.Application.Usecases.Applications;
using UHB.Application.Usecases.Hostels;
using UHB.Application.Usecases.Rooms;
using UHB.Application.Usecases.Students;
using UHB.Infrastructure.Persistence;

namespace UHB.Infrastructure;

public static class ServiceRegistration
{
    public static void RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        RegisterDbServices(services, configuration);
        RegisterRepositories(services);
        RegisterApplicationServices(services);
    }
    private static void RegisterDbServices(this IServiceCollection services, IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("UHB");
        services.AddDbContext<UhbContext>(
            options =>
            {
                options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 35)));
            }, ServiceLifetime.Scoped);
    }
    private static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
    }
    private static void RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IApplicationService, ApplicationService>();
        services.AddScoped<IHostelService, HostelService>();
        services.AddScoped<IRoomService, RoomService>();
        services.AddScoped<IStudentService, StudentService>();
    }
}
