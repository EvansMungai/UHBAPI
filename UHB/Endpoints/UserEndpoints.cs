using UHB.Application.Dtos.Authentication;
using UHB.Application.Dtos.Authentication.User;
using UHB.Extensions.RouteHandlers;
using UHB.Features.AuthenticationManagement.Services;

namespace UHB.Endpoints;

public class UserEndpoints : IRouteRegistrar
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        MapUserEndpoints(app);
        MapRoleEndpoints(app);
    }
    public void MapUserEndpoints(IEndpointRouteBuilder app)
    {
        RouteGroupBuilder group = app.MapGroup("").WithTags("User Management").RequireAuthorization("CanAccessManagement");
        group.MapPost("/control", async (IUserManagementService service, SpecialRegisterRequest specialUser) => await service.RegisterSpecialUsers(specialUser));
        group.MapGet("/users", async (IUserManagementService service) => await service.GetUsers());
        group.MapGet("/user/{id}", async (IUserManagementService service, string id) => await service.GetUser(id));
        group.MapGet("/special-users", async (IUserManagementService service) => await service.GetSpecialUsers());
        group.MapDelete("/user/{id}", async (IUserManagementService service, string id) => await service.RemoveUser(id));
        group.MapPut("/user-role/{id}", async (IUserManagementService service, string id, string role) => await service.AssignRoleToUserAsync(id, role));
        //group.MapPut("/user-details/{id}", async (IUserManagementService service, string id, user update) => await service.UpdateUserDetails(id, update));
        group.MapPut("/change-password", async (IUserManagementService service, ChangePasswordRequest model, HttpContext context) => await service.ChangeUserPassword(model, context));
    }
    public void MapRoleEndpoints(IEndpointRouteBuilder app)
    {
        RouteGroupBuilder group = app.MapGroup("").WithTags("Role Management").RequireAuthorization("CanAccessManagement");
        group.MapGet("/roles", async (IUserManagementService service) => await service.GetRoles());
        group.MapGet("/role/{roleName}", async (IUserManagementService service, string roleName) => await service.EnsureRoleExists(roleName));
        group.MapPost("/role", async (IUserManagementService service, string role) => await service.CreateRole(role));
        group.MapPut("/role/{roleName}", async (IUserManagementService service, string roleName, string newRoleName) => await service.EditRole(roleName, newRoleName));
        group.MapDelete("/role/{roleName}", async (IUserManagementService service, string roleName) => await service.RemoveRole(roleName));
    }
}
