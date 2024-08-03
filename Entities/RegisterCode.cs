namespace Entities;

public class RegisterCode
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public bool IsUsed { get; set; }
    public int? UserId { get; set; }
    public User? User { get; set; }
}