using Microsoft.AspNetCore.Identity;
using UHB.Features.StudentManagement.Models;

namespace UHB.Features.AuthenticationManagement.Models;

public partial class User : IdentityUser
{
    public DateTime LastLoginTime { get; set; }

    public string? RegNo { get; set; }

    public virtual Student? RegNoNavigation { get; set; }
}
