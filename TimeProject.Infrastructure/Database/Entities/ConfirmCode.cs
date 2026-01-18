using TimeProject.Domain.Entities;
using TimeProject.Domain.Entities.Enums;
using TimeProject.Infrastructure.Database.Entities.Shared;

namespace TimeProject.Infrastructure.Database.Entities;

public class ConfirmCode : WithOwnerEntity, IConfirmCode
{
    public string CodeId { get; set; } = null!;
    public ConfirmCodeType Type { get; set; }
    public bool IsUsed { get; set; }
    public bool WasSent { get; set; }
    public DateTime Expiration { get; set; }

    public User? User { get; set; }
}