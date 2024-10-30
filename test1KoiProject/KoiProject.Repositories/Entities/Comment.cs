using System;
using System.Collections.Generic;

namespace KoiProject.Repositories.Entities;

public partial class Comment
{
    public int CommentId { get; set; }

    public int? UserId { get; set; }

    public int? RecommendationId { get; set; }

    public string? CommentText { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Recommendation? Recommendation { get; set; }

    public virtual User? User { get; set; }
}
