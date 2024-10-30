using System;
using System.Collections.Generic;

namespace KoiProject.Repositories.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public DateOnly BirthYear { get; set; }

    public string? Element { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? RoleId { get; set; }

    public string? Preference { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Consultation> Consultations { get; set; } = new List<Consultation>();

    public virtual ICollection<KoiOwnership> KoiOwnerships { get; set; } = new List<KoiOwnership>();

    public virtual ICollection<PaymentHistory> PaymentHistories { get; set; } = new List<PaymentHistory>();

    public virtual ICollection<PondDetail> PondDetails { get; set; } = new List<PondDetail>();

    public virtual ICollection<Recommendation> Recommendations { get; set; } = new List<Recommendation>();

    public virtual UserRole? Role { get; set; }
}
