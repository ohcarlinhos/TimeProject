using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities.Enums;

namespace TimeProject.Infrastructure.Entities;

public class User : IUser
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public UserRoleType UserRole { get; set; } = UserRoleType.Normal;
    public int Utc { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}