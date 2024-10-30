using System;
using System.Collections.Generic;

namespace KoiProject.Repositories.Entities;

public partial class UserRole
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
