using TimeProject.Domain.Dtos.Users;
using TimeProject.Infrastructure.Entities.Enums;

namespace TimeProject.Infrastructure.ObjectValues.Users;

public class UserOutDto : IUserOutDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public UserRoleType UserRoleType { get; set; }
    public string UserRoleLabel => UserRoleType.ToString();

    public bool IsActive { get; set; }
    public bool IsAdmin => UserRoleType == UserRoleType.Admin;

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public DateTime? LastUserAccess { get; set; }
    public string? LastUserAccessType { get; set; }
    public string? LastUserAccessProvider { get; set; }
}