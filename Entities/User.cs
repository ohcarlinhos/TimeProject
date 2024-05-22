using System.ComponentModel.DataAnnotations;

namespace Entities;

public enum UserRole
{
    Admin,
    NormalUser,
    PayingUser,
    GuestUser
}

public class User
{
    public int Id { get; set; }

    [MinLength(3)]
    public string Name { get; set; } = null!;

    [EmailAddress, MinLength(8)]
    public string Email { get; set; } = null!;

    [MinLength(8)]
    public string Password { get; set; } = null!;
    public UserRole UserRole { get; set; } = UserRole.NormalUser;
    
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}