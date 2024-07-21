namespace Entities;

public class RegisterCode
{
    public string Key { get; set; } = Guid.NewGuid().ToString();
    public bool IsUsed { get; set; } = false;
    public int? UserId { get; set; } = null;
}