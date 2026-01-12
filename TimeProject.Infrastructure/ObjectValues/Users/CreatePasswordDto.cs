using System.ComponentModel.DataAnnotations;
using TimeProject.Domain.RemoveDependencies.Dtos.User;

namespace TimeProject.Infrastructure.ObjectValues.Users;

public class CreatePasswordDto : ICreatePasswordDto
{
    [MinLength(8)]
    [MaxLength(48)]
    [Required]
    public string Password { get; set; } = string.Empty;
}