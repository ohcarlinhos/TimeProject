using Entities;

namespace Shared.User;

public class UserMap
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
    public UserRole UserRole { get; set; }
    public string UserRoleLabel => UserRole.ToString();
}