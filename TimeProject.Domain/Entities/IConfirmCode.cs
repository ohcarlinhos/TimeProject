using TimeProject.Infrastructure.Database.Entities.Enums;

namespace TimeProject.Domain.Entities;

public interface IConfirmCode
{
    string Id { get; set; }
    DateTime ExpireDate { get; set; }
    bool IsUsed { get; set; }
    bool WasSent { get; set; }
    int UserId { get; set; }
    ConfirmCodeType Type { get; set; }
}