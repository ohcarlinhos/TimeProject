using System.ComponentModel.DataAnnotations;

namespace API.Modules.User.Entities;

public enum UserRole
{
    Admin,
    NormalUser,
    PayingUser,
    GuestUser
}

public class UserEntity
{
    public int Id { get; set; }

    [MinLength(3)]
    public string Name { get; set; } = null!;

    [EmailAddress, MinLength(8)]
    public string Email { get; set; } = null!;

    [MinLength(8)]
    public string Password { get; set; } = null!;
    public UserRole UserRole { get; set; } = UserRole.NormalUser;
    
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}