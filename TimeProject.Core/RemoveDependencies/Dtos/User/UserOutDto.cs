using TimeProject.Core.Domain.Entities;

namespace TimeProject.Core.RemoveDependencies.Dtos.User;

public class UserOutDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public UserRole UserRole { get; set; }
    public string UserRoleLabel => UserRole.ToString();

    public bool IsActive { get; set; }
    public bool IsAdmin => UserRole == UserRole.Admin;

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public DateTime? LastUserAccess { get; set; }
    public string? LastUserAccessType { get; set; }
    public string? LastUserAccessProvider { get; set; }
}