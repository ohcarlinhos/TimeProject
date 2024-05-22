using Entities;

namespace API.Modules.User.DTO;

public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public UserRole UserRole { get; set; }
    public string UserRoleLabel => UserRole.ToString();
}