using System;
using System.Collections.Generic;

namespace CNLTHD.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Role { get; set; }

    public string? JwtToken { get; set; }

    public DateTime? CreatedAt { get; set; }
}
