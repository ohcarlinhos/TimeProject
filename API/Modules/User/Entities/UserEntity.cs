using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Modules.User.Entities;

[Table("users"), Index(nameof(Email), IsUnique = true)]
public class UserEntity
{
    [Key] public int Id { get; set; }

    [Required, MinLength(3), MaxLength(120)]
    public string Name { get; set; }

    [Required, EmailAddress, MinLength(8), MaxLength(64)]
    public string Email { get; set; }

    [Required, MinLength(8), MaxLength(32)]
    public string? Password { get; set; }
}