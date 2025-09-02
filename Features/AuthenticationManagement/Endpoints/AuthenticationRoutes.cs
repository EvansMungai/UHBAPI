using UHB.Extensions.RouteHandlers;
using UHB.Features.AuthenticationManagement.Models;

namespace UHB.Features.AuthenticationManagement.Endpoints;

public class AuthenticationRoutes : IRouteRegistrar
{
    public void RegisterRoutes(WebApplication app)
    {
        MapAuthenticationRoutes(app);
    }
    public void MapAuthenticationRoutes(WebApplication application)
    {
        application.MapGet("/", () => "Welcome to UHB API V2");

        var app = application.MapGroup("").WithTags("Authentication");
        app.MapPost("/register", (User model, AuthenticationHandler handler) => handler.RegisterUser(model));
        app.MapPost("/login", (User model, AuthenticationHandler handler) => handler.Login(model));
        app.MapPost("/logout", (AuthenticationHandler handler) => handler.LogOut());
    }
}
