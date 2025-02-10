namespace Entities;

public class UserPasswordEntity
{
    public int UserId { get; set; }
    public string Password { get; set; } = string.Empty;
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}