using System.ComponentModel.DataAnnotations;

namespace TimeProject.Core.Application.Dtos.User;

public class UpdateRoleDto
{
    [Required] public string Role { get; set; } = string.Empty;
}