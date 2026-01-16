using TimeProject.Domain.Dtos.Codes;
using TimeProject.Domain.Entities.Enums;
using TimeProject.Infrastructure.Database.Entities.Enums;

namespace TimeProject.Infrastructure.ObjectValues.Codes;

public class ConfirmCodeOutDto : IConfirmCodeOutDto
{
    public DateTime ExpireDate { get; set; }
    public bool IsUsed { get; set; }
    public bool WasSent { get; set; }
    public ConfirmCodeType Type { get; set; }
    public string FormattedExpireDate => ExpireDate.ToString("dd/MM/yyyy HH:mm:ss");
}