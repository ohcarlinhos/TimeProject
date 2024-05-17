using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace API.Modules.User.Entities;

public enum UserRole
{
    Admin,
    NormalUser,
    PayingUser,
    GuestUser
}

[Table("users"), Index(nameof(Email), IsUnique = true)]
public class UserEntity
{
    [Key] 
    public int Id { get; set; }

    [Required, MinLength(3), MaxLength(120)]
    public string Name { get; set; } = null!;

    [Required, EmailAddress, MinLength(8), MaxLength(64)]
    public string Email { get; set; } = null!;

    [Required, MinLength(8), MaxLength(32)]
    public string Password { get; set; } = null!;
    
    [Required]
    public UserRole UserRole { get; set; } = UserRole.NormalUser;
}