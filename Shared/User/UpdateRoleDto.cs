using System.ComponentModel.DataAnnotations;

namespace Shared.User;

public class UpdateRoleDto
{
    [Required] public string Role { get; set; } = "";
}