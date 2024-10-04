using System;
using System.Collections.Generic;

namespace UHB.uhb;

public partial class User
{
    public string Username { get; set; } = null!;

    public string? Password { get; set; }

    public string? Role { get; set; }

    public string? RegNo { get; set; }

    public virtual Student? RegNoNavigation { get; set; }
}
