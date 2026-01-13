using System.ComponentModel.DataAnnotations;
using TimeProject.Domain.Dtos.Users;

namespace TimeProject.Infrastructure.ObjectValues.Users;

public class UpdatePasswordDto : IUpdatePasswordDto
{
    [MinLength(8)]
    [MaxLength(48)]
    [Required]
    public string Password { get; set; } = string.Empty;

    [MinLength(8)]
    [MaxLength(48)]
    [Required]
    public string OldPassword { get; set; } = string.Empty;
}