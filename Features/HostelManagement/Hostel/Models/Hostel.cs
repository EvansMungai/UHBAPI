using System;
using System.Collections.Generic;

namespace UHB.Features.HostelManagement.Hostel.Models;

public partial class Hostel
{
    public string HostelNo { get; set; } = null!;

    public string? HostelName { get; set; }

    public string? Capacity { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
