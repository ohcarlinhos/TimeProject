using System.ComponentModel.DataAnnotations;
using TimeProject.Domain.RemoveDependencies.Dtos.User;

namespace TimeProject.Infrastructure.ObjectValues.User;

public class RecoveryDto : IRecoveryDto
{
    [Required] [EmailAddress] public string Email { get; set; } = string.Empty;
}