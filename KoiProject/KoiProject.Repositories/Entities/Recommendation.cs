using System;
using System.Collections.Generic;

namespace KoiProject.Repositories.Entities;


public partial class Recommendation
{
    public int RecommendationId { get; set; }

    public int? UserId { get; set; }

    public int? PondId { get; set; }

    public int? KoiId { get; set; }

    public string? RecommendationText { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual KoiFish? Koi { get; set; }

    public virtual PondDetail? Pond { get; set; }

    public virtual User? User { get; set; }
}
