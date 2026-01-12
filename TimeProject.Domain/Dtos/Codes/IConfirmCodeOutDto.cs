using TimeProject.Infrastructure.Entities.Enums;

namespace TimeProject.Domain.Dtos.Codes;

public interface IConfirmCodeOutDto
{
    DateTime ExpireDate { get; set; }
    bool IsUsed { get; set; }
    bool WasSent { get; set; }
    ConfirmCodeType Type { get; set; }
    string FormattedExpireDate { get; }
}