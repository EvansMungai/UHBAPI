using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using UHB.Data.Infrastructure;
using UHB.Features.AuthenticationManagement.Models;

namespace UHB.Features.AuthenticationManagement.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IUserManagementService _userManagementService;
    private readonly UhbContext _context;
    public AuthenticationService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, IUserManagementService userManagementService, UhbContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _userManagementService = userManagementService;
        _context = context;
    }
    public async Task<IResult> RegisterUser(User model)
    {
        User user1 = new User
        {
            UserName = model.UserName,
            RegNo = model.RegNo,
            PhoneNumber = model.PhoneNumber,
            Email = model.Email,
            PasswordHash = model.PasswordHash,
            LastLoginTime = DateTime.Now,
        };
        try
        {
            var result = await _userManager.CreateAsync(user1, user1.PasswordHash);
            if (result.Succeeded)
            {
                var roleAssignmentResult = await _userManagementService.AssignRoleToUserAsync(user1.UserName, "Student");
                var query = from user in _context.Users
                            join userRoles in _context.UserRoles on user.Id equals userRoles.UserId
                            join role in _context.Roles on userRoles.RoleId equals role.Id
                            where user.UserName == user1.UserName
                            select new
                            {
                                user.UserName,
                                user.Email,
                                user.PhoneNumber,
                                Role = role.Name,
                                LastLoginTime = user.LastLoginTime
                            };
                var userDetails = query.ToList();
                return Results.Ok(userDetails);
            }
            return Results.BadRequest(result.Errors);
        }
        catch (Exception ex)
        {
            return Results.BadRequest("Error occurred!: " + ex.ToString());
        }
    }
    public async Task<IResult> Login(User model)
    {
        var retrievedUser = await _userManager.FindByNameAsync(model.UserName);
        if (retrievedUser != null)
        {
            var passwordCheck = await _userManager.CheckPasswordAsync(retrievedUser, model.PasswordHash);
            if (passwordCheck)
            {
                retrievedUser.LastLoginTime = DateTime.Now;
                var updateUserResult = await _userManager.UpdateAsync(retrievedUser);
                if (!updateUserResult.Succeeded)
                    return Results.BadRequest("Failed to update LastLoginTime");


                await _signInManager.SignInAsync(retrievedUser, false);

                var query = from user in _context.Users
                            join userRoles in _context.UserRoles on user.Id equals userRoles.UserId
                            join role in _context.Roles on userRoles.RoleId equals role.Id
                            where user.UserName == retrievedUser.UserName
                            select new
                            {
                                user.UserName,
                                user.Email,
                                user.PhoneNumber,
                                Role = role.Name,
                            };
                var userDetails = query.ToList();
                return Results.Ok(userDetails);
            }
            else
            {
                return Results.BadRequest("Incorrect Password.");
            }
        }
        else
        {
            return Results.BadRequest("User not found");
        }
    }
    public async Task<IResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        return Results.Ok("Successfully logged out");
    }
}
