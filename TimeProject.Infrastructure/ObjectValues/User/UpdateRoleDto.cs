using System.ComponentModel.DataAnnotations;
using TimeProject.Domain.RemoveDependencies.Dtos.User;

namespace TimeProject.Infrastructure.ObjectValues.User;

public class UpdateRoleDto : IUpdateRoleDto
{
    [Required] public string Role { get; set; } = string.Empty;
}