using System;
using System.Collections.Generic;

namespace KoiProject.Repositories.Entities;


public partial class PondMaintenance
{
    public int MaintenanceId { get; set; }

    public int? PondId { get; set; }

    public DateOnly MaintenanceDate { get; set; }

    public string? Description { get; set; }

    public DateOnly? NextScheduledDate { get; set; }

    public virtual PondDetail? Pond { get; set; }
}
