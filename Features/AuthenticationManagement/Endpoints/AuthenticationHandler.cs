using UHB.Extensions.RouteHandlers;
using UHB.Features.AuthenticationManagement.Models;
using UHB.Features.AuthenticationManagement.Services;

namespace UHB.Features.AuthenticationManagement.Endpoints;

public class AuthenticationHandler : IHandler
{
    public static string RouteName => "Authentication Management";
    private readonly IAuthenticationService _authenticationService;
    public AuthenticationHandler(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }
    public Task<IResult> RegisterUser(User model) => _authenticationService.RegisterUser(model);
    public Task<IResult> Login(User model) => _authenticationService.Login(model);
    public Task<IResult> LogOut() => _authenticationService.LogOut();
}
