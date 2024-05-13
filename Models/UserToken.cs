using System;
using System.Collections.Generic;

namespace HRManagement.Models;

public partial class UserToken
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? LoginProvider { get; set; }

    public string? Name { get; set; }

    public string? Value { get; set; }

    public virtual User User { get; set; } = null!;
}
