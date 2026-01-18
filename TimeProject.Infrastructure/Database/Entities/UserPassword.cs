using TimeProject.Domain.Entities;

namespace TimeProject.Infrastructure.Database.Entities;

public class UserPassword : IUserPassword
{
    public int PasswordId { get; set; }
    public string Password { get; set; } = string.Empty;
    public int UserId { get; set; }
    public bool IsActive { get; set; }
}