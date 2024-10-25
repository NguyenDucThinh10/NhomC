using System;
using System.Collections.Generic;

namespace KoiProject.Repositories.Entities;


public partial class PaymentHistory
{
    public int PaymentId { get; set; }

    public int? UserId { get; set; }

    public decimal PaymentAmount { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string? PaymentMethod { get; set; }

    public string? Description { get; set; }

    public virtual User? User { get; set; }
}
