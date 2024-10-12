using System;
using System.Collections.Generic;

namespace UHB.uhb;

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
