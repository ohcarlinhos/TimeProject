using System.ComponentModel.DataAnnotations;
using TimeProject.Domain.Dtos.Users;

namespace TimeProject.Infrastructure.ObjectValues.Pagination.Users;

public class UpdateRoleDto : IUpdateRoleDto
{
    [Required] public string Role { get; set; } = string.Empty;
}