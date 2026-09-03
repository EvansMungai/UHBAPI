using UHB.Application.Dtos.Authentication.User;
using UHB.Extensions.RouteHandlers;
using UHB.Features.AuthenticationManagement.Services;

namespace UHB.Endpoints;

public class AuthenticationEndpoints : IRouteRegistrar
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/", () => "Welcome to UHB API V2");

        RouteGroupBuilder group = app.MapGroup("").WithTags("Authentication");
        group.MapPost("/register", async (IAuthenticationService service, RegisterRequest model, string platform) => await service.Register(model, platform));
        group.MapPost("/login", async (IAuthenticationService service, LoginRequest model, string platform) => await service.Login(model, platform));
        group.MapPost("/logout", async (IAuthenticationService service) => await service.LogOut());
    }
}
