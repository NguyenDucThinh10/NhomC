using System;
using System.Collections.Generic;

namespace KoiProject.Repositories.Entities;

public partial class KoiOwnership
{
    public int OwnershipId { get; set; }

    public int? UserId { get; set; }

    public int? PondId { get; set; }

    public int? KoiId { get; set; }

    public int Quantity { get; set; }

    public DateOnly? PurchaseDate { get; set; }

    public virtual KoiFish? Koi { get; set; }

    public virtual PondDetail? Pond { get; set; }

    public virtual User? User { get; set; }
}
