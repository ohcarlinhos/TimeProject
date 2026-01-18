using TimeProject.Domain.Entities.Enums;
using TimeProject.Infrastructure.Database.Entities.Enums;

namespace TimeProject.Domain.Dtos.Users;

public interface IUserOutDto
{
    int Id { get; set; }
    string Name { get; set; }
    string Email { get; set; }
    UserRoleType UserRoleType { get; set; }
    string UserRoleLabel { get; }
    bool IsActive { get; set; }
    bool IsAdmin { get; }
    DateTime? LastAccess { get; set; }
    string? LastAccessType { get; set; }
    string? LastAccessProvider { get; set; }
}