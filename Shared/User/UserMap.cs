using Entities;

namespace Shared.User;

public class UserMap
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public bool IsVerified { get; set; }
    public UserRole UserRole { get; set; }
    public string UserRoleLabel => UserRole.ToString();
    public DateTime CreatedAt { get; set; }
}