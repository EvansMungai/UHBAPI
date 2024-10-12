using System;
using System.Collections.Generic;

namespace UHB.uhb;

public partial class Room
{
    public string RoomNo { get; set; } = null!;

    public string? HostelNo { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual Hostel? HostelNoNavigation { get; set; }
}
