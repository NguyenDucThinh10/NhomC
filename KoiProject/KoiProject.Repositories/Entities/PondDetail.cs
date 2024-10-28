using System;
using System.Collections.Generic;

namespace KoiProject.Repositories.Entities;

public partial class PondDetail
{
    public int PondId { get; set; }

    public int? UserId { get; set; }

    public string? Location { get; set; }

    public decimal? WidthCm { get; set; }

    public decimal? LengthCm { get; set; }

    public decimal? DepthCm { get; set; }

    public string? Shape { get; set; }

    public string? Direction { get; set; }

    public int? PondScore { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<KoiOwnership> KoiOwnerships { get; set; } = new List<KoiOwnership>();

    public virtual ICollection<PondMaintenance> PondMaintenances { get; set; } = new List<PondMaintenance>();

    public virtual ICollection<Recommendation> Recommendations { get; set; } = new List<Recommendation>();

    public virtual User? User { get; set; }
}
