using UHB.Features.AuthenticationManagement.Models;

namespace UHB.Features.AuthenticationManagement.Services;

public interface IAuthenticationService
{
    Task<IResult> RegisterUser(User model);
    Task<IResult> Login(User model);
    Task<IResult> LogOut();
}
