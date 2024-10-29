using System;
using System.Collections.Generic;

namespace KoiProject.Repositories.Entities;

public partial class KoiFish
{
    public int KoiId { get; set; }

    public string KoiName { get; set; } = null!;

    public string? Color { get; set; }

    public decimal? SizeCm { get; set; }

    public string? FengShuiMeaning { get; set; }

    public string? SuitableElement { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<KoiOwnership> KoiOwnerships { get; set; } = new List<KoiOwnership>();

    public virtual ICollection<Recommendation> Recommendations { get; set; } = new List<Recommendation>();
}
