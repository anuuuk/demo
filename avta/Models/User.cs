using System;
using System.Collections.Generic;

namespace avta.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? FailedLoginAttempts { get; set; }

    public bool? IsLocked { get; set; }

    public bool? IsFirstLogin { get; set; }

    public DateTime? LastLoginDate { get; set; }

    public virtual ICollection<CleaningSchedule> CleaningSchedules { get; set; } = new List<CleaningSchedule>();
}
