using Microsoft.AspNetCore.Identity;
using UHB.Data.Infrastructure;
using UHB.Features.AuthenticationManagement.Models;

namespace UHB.Extensions.ServiceHandlers;

public static class AuthenticationServiceRegistration
{
    public static void ConfigureAuthenticationServices(this IServiceCollection services)
    {
        services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<UhbContext>().AddDefaultTokenProviders();
        services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/login";
            options.Cookie.HttpOnly = true;
            options.Cookie.SameSite = SameSiteMode.None;
            options.Cookie.SecurePolicy = CookieSecurePolicy.None;
        });
    }
}
