using Entities;

namespace Shared.Codes;

public class ConfirmCodeMap
{
    public DateTime ExpireDate { get; set; }
    public bool IsUsed { get; set; }
    public bool WasSent { get; set; }
    public ConfirmCodeType Type { get; set; }
    public string FormattedExpireDate => ExpireDate.ToLocalTime().ToString();
}

