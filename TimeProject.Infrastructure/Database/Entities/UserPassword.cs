using TimeProject.Domain.Entities;

namespace TimeProject.Infrastructure.Database.Entities;

public class UserPassword : IUserPassword
{
    public int UserId { get; set; }
    public string Password { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}