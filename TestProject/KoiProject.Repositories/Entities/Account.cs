using System;
using System.Collections.Generic;

namespace KoiProject.Repositories.Entities;

public partial class Account
{
    public int AccountId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? UserRoleId { get; set; }

    public virtual UserRole? UserRole { get; set; }
}
