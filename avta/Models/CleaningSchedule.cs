using System;
using System.Collections.Generic;

namespace avta.Models;

public partial class CleaningSchedule
{
    public int Id { get; set; }

    public int? RoomId { get; set; }

    public DateTime CleaningDate { get; set; }

    public int? UserId { get; set; }

    public string Status { get; set; } = null!;

    public virtual Room? Room { get; set; }

    public virtual User? User { get; set; }
}
