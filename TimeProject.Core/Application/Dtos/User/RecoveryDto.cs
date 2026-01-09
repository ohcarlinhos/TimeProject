using System.ComponentModel.DataAnnotations;

namespace TimeProject.Core.Application.Dtos.User;

public class RecoveryDto
{
    [Required] [EmailAddress] public string Email { get; set; } = string.Empty;
}