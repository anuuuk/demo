using System;
using System.Collections.Generic;

namespace avta.Models;

public partial class Service
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<GuestService> GuestServices { get; set; } = new List<GuestService>();
}
