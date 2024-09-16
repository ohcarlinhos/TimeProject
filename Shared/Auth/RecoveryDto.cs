using System.ComponentModel.DataAnnotations;

namespace Shared.Auth;

public class RecoveryDto
{
    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;
}