using System;
using System.Collections.Generic;

namespace avta.Models;

public partial class GuestService
{
    public int Id { get; set; }

    public int? ReservationId { get; set; }

    public int? ServiceId { get; set; }

    public int Quantity { get; set; }

    public string Status { get; set; } = null!;

    public virtual Reservation? Reservation { get; set; }

    public virtual Service? Service { get; set; }
}
