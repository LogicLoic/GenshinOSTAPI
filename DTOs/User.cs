using System;

namespace DTOs;

public class User
{
    public long Id { get; set; }
    public string? Username { get; set; }
    public Role Role { get; set; }
}
