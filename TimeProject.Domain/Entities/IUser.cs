using TimeProject.Infrastructure.Entities.Enums;

namespace TimeProject.Domain.Entities;

public interface IUser
{
    int Id { get; set; }
    string Name { get; set; }
    string Email { get; set; }
    UserRoleType UserRole { get; set; }
    int Utc { get; set; }
    bool IsActive { get; set; }
}