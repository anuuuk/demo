using System;
using System.Collections.Generic;

namespace avta.Models;

public partial class Payment
{
    public int Id { get; set; }

    public int? ReservationId { get; set; }

    public decimal Amount { get; set; }

    public DateTime PaymentDate { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public virtual Reservation? Reservation { get; set; }
}
