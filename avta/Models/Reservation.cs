using System;
using System.Collections.Generic;

namespace avta.Models;

public partial class Reservation
{
    public int Id { get; set; }

    public int GuestId { get; set; }

    public int RoomId { get; set; }

    public DateTime CheckInDate { get; set; }

    public DateTime CheckOutDate { get; set; }

    public decimal? TotalPrice { get; set; }

    public string Status { get; set; } = null!;

    public virtual Guest Guest { get; set; } = null!;

    public virtual ICollection<GuestService> GuestServices { get; set; } = new List<GuestService>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Room Room { get; set; } = null!;
}
