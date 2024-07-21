namespace Entities;

public class RegisterCode
{
    public string Key { get; set; } = Guid.NewGuid().ToString();
    public bool IsUsed { get; set; }
    public int? UserId { get; set; }
}