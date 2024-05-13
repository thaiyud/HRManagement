using System;
using System.Collections.Generic;

namespace HRManagement.Models;

public partial class UserLogin
{
    public int Id { get; set; }

    public string? LoginProvider { get; set; }

    public string? ProviderKey { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
