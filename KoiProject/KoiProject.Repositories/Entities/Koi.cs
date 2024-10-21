using System;
using System.Collections.Generic;

namespace KoiProject.Repositories.Entities;

public partial class Koi
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Species { get; set; } = null!;

    public string SuitableElement { get; set; } = null!;
}
