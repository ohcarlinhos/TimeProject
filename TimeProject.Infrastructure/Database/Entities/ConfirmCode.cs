using TimeProject.Domain.Entities;
using TimeProject.Domain.Entities.Enums;

namespace TimeProject.Infrastructure.Database.Entities;

public class ConfirmCode : IConfirmCode
{
    public string CodeId { get; set; } = null!;
    public ConfirmCodeType Type { get; set; }
    public bool IsUsed { get; set; }
    public bool WasSent { get; set; }
    public DateTime Expiration { get; set; }
    public int UserId { get; set; }

    public User? User { get; set; }
}