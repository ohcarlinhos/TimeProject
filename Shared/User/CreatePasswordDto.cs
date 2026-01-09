using System.ComponentModel.DataAnnotations;

namespace Shared.User;

public class CreatePasswordDto
{
    [MinLength(8)]
    [MaxLength(48)]
    [Required]
    public string Password { get; set; } = string.Empty;
}