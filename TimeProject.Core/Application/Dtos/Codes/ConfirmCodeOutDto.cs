using TimeProject.Core.Domain.Entities;

namespace TimeProject.Core.Application.Dtos.Codes;

public class ConfirmCodeOutDto
{
    public DateTime ExpireDate { get; set; }
    public bool IsUsed { get; set; }
    public bool WasSent { get; set; }
    public ConfirmCodeType Type { get; set; }
    public string FormattedExpireDate => ExpireDate.ToString("dd/MM/yyyy HH:mm:ss");
}