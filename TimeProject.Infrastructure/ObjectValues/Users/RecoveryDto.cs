using System.ComponentModel.DataAnnotations;
using TimeProject.Domain.Dtos.Users;

namespace TimeProject.Infrastructure.ObjectValues.Users;

public class RecoveryDto : IRecoveryDto
{
    [Required] [EmailAddress] public string Email { get; set; } = string.Empty;
}