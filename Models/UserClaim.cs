﻿using System;
using System.Collections.Generic;

namespace HRManagement.Models;

public partial class UserClaim
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? ClaimType { get; set; }

    public string? ClaimValue { get; set; }

    public virtual User User { get; set; } = null!;
}
