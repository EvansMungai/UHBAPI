using UHB.Features.ApplicationManagement.Models;
using UHB.Features.AuthenticationManagement.UserManagement.Models;

namespace UHB.Features.StudentManagement.Models;

public partial class Student
{
    public string RegNo { get; set; } = null!;

    public string? Surname { get; set; }

    public string? FirstName { get; set; }

    public string? SecondName { get; set; }

    public string? Gender { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
