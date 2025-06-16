using System;
using System.Collections.Generic;

namespace avta.Models;

public partial class RoomAccess
{
    public decimal Id { get; set; }

    public int? GuestId { get; set; }

    public int? RoomId { get; set; }

    public string AccessCardCode { get; set; } = null!;

    public string Status { get; set; } = null!;

    public virtual Guest? Guest { get; set; }

    public virtual Room? Room { get; set; }
}
