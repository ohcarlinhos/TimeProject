namespace Entities;

public class RegisterCodeEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public bool IsUsed { get; set; }
    public int? UserId { get; set; }
    public UserEntity? User { get; set; }
}