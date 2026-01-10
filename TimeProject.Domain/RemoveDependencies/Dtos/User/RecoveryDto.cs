using System.ComponentModel.DataAnnotations;

namespace TimeProject.Domain.RemoveDependencies.Dtos.User;

public class RecoveryDto
{
    [Required] [EmailAddress] public string Email { get; set; } = string.Empty;
}