using System.ComponentModel.DataAnnotations;

namespace TimeProject.Core.RemoveDependencies.Dtos.User;

public class UpdateRoleDto
{
    [Required] public string Role { get; set; } = string.Empty;
}