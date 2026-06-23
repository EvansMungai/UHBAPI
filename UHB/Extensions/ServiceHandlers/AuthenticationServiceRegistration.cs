using Microsoft.AspNetCore.Identity;
using UHB.Domain.Entities;
using UHB.Infrastructure.Persistence;

namespace UHB.Extensions.ServiceHandlers;

public static class AuthenticationServiceRegistration
{
    public static void ConfigureAuthenticationServices(this IServiceCollection services)
    {
        services.AddIdentity<UserDomain, IdentityRole>().AddEntityFrameworkStores<UhbContext>().AddDefaultTokenProviders();
        services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/login";
            options.Cookie.HttpOnly = true;
            options.Cookie.SameSite = SameSiteMode.None;
            options.Cookie.SecurePolicy = CookieSecurePolicy.None;
        });
        services.AddAuthentication();
        services.AddAuthorization();
    }
}
