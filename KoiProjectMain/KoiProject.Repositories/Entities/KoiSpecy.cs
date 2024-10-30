using System;
using System.Collections.Generic;

namespace KoiProject.Repositories.Entities;

public partial class KoiSpecy
{
    public int KoiId { get; set; }

    public string Name { get; set; } = null!;

    public string SuitableElement { get; set; } = null!;

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<Consultation> Consultations { get; set; } = new List<Consultation>();
}
