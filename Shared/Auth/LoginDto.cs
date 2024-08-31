using System.ComponentModel.DataAnnotations;

namespace Shared.Auth;

public class LoginDto
{
    [Required, EmailAddress] public string Email { get; set; } = string.Empty;
    [Required, MinLength(8), MaxLength(48)] public string Password { get; set; } = string.Empty;
}