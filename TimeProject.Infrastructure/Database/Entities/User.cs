using TimeProject.Domain.Entities;
using TimeProject.Domain.Entities.Enums;
using TimeProject.Infrastructure.Database.Entities.Shared;

namespace TimeProject.Infrastructure.Database.Entities;

public class User : IUser
{
    public int UserId { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public UserRoleType UserRole { get; set; } = UserRoleType.Normal;
    public string Timezone { get; set; }
    public bool IsActive { get; set; } = true;
}