using System;
using System.Collections.Generic;

namespace avta.Models;

public partial class StatisticsHotel
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public decimal? OccupancyRate { get; set; }

    public decimal? Adr { get; set; }

    public decimal? Revpar { get; set; }

    public decimal? Revenue { get; set; }
}
