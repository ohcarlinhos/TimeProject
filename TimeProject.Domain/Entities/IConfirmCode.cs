using TimeProject.Domain.Entities.Enums;
using TimeProject.Domain.Entities.Shared;

namespace TimeProject.Domain.Entities;

public interface IConfirmCode : IWithOwnerEntity
{
    string CodeId { get; set; }
    DateTime Expiration { get; set; }
    bool IsUsed { get; set; }
    bool WasSent { get; set; }
    ConfirmCodeType Type { get; set; }
}