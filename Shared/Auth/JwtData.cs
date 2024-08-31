namespace Shared.Auth;

public class JwtData
{
    public string Token { get; set; } = string.Empty;
    public DateTime Now { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }
}