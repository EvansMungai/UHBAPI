namespace UHB.Features.AuthenticationManagement.Services;

public static class ServiceRegistration
{
    public static void RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUserManagementService, UserManagementService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
    }
}
