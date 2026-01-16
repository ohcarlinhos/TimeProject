using TimeProject.Domain.Entities.Enums;
using TimeProject.Infrastructure.Database.Entities.Enums;

namespace TimeProject.Domain.Entities;

public interface IUser
{
    int UserId { get; set; }
    string Name { get; set; }
    string Email { get; set; }
    UserRoleType UserRole { get; set; }
    string Timezone { get; set; }
    bool IsActive { get; set; }
}