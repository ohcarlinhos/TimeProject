using System.ComponentModel.DataAnnotations;

namespace Shared.User;

public class RecoveryDto
{
    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;
}