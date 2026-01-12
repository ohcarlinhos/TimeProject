using TimeProject.Infrastructure.Entities.Enums;

namespace TimeProject.Domain.RemoveDependencies.Dtos.User;

public interface IUserOutDto
{
    int Id { get; set; }
    string Name { get; set; }
    string Email { get; set; }
    UserRoleType UserRoleType { get; set; }
    string UserRoleLabel { get; }
    bool IsActive { get; set; }
    bool IsAdmin { get; }
    DateTime CreatedAt { get; set; }
    DateTime? UpdatedAt { get; set; }
    DateTime? LastUserAccess { get; set; }
    string? LastUserAccessType { get; set; }
    string? LastUserAccessProvider { get; set; }
}