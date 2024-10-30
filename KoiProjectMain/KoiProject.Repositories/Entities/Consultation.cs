using System;
using System.Collections.Generic;

namespace KoiProject.Repositories.Entities;

public partial class Consultation
{
    public int ConsultId { get; set; }

    public int? UserId { get; set; }

    public int? KoiId { get; set; }

    public int? PondId { get; set; }

    public DateTime? Date { get; set; }

    public virtual KoiSpecy? Koi { get; set; }

    public virtual PondFeature? Pond { get; set; }

    public virtual User? User { get; set; }
}
