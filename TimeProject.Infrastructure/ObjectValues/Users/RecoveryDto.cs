using System.ComponentModel.DataAnnotations;
using TimeProject.Domain.Dtos.Users;

namespace TimeProject.Infrastructure.ObjectValues.Pagination.Users;

public class RecoveryDto : IRecoveryDto
{
    [Required] [EmailAddress] public string Email { get; set; } = string.Empty;
}