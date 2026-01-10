using System.ComponentModel.DataAnnotations;

namespace TimeProject.Core.RemoveDependencies.Dtos.User;

public class UpdateByAdminPasswordDto
{
    [MinLength(8)]
    [MaxLength(48)]
    [Required]
    public string Password { get; set; } = string.Empty;
}