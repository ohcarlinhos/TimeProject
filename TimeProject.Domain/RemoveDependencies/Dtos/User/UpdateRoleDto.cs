using System.ComponentModel.DataAnnotations;

namespace TimeProject.Domain.RemoveDependencies.Dtos.User;

public class UpdateRoleDto
{
    [Required] public string Role { get; set; } = string.Empty;
}