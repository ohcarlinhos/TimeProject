namespace Entities;

public enum ConfirmCodeType
{
    Register,
    Recovery
}

public class ConfirmCodeEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public DateTime ExpireDate { get; set; }
    public bool IsUsed { get; set; }
    public bool WasSent { get; set; }
    public int UserId { get; set; }
    public ConfirmCodeType Type { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public UserEntity? User { get; set; }
}