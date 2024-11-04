using System;
using System.Collections.Generic;

namespace KoiProject.Repositories.Entities;

public partial class PondFeature
{
    public int PondId { get; set; }

    public string Shape { get; set; } = null!;

    public string SuitableElement { get; set; } = null!;

    public string? Direction { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Consultation> Consultations { get; set; } = new List<Consultation>();
}
