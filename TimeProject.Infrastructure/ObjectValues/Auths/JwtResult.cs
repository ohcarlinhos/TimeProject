using TimeProject.Domain.RemoveDependencies.Dtos.Auth;

namespace TimeProject.Infrastructure.ObjectValues.Auths;

public class JwtResult : IJwtResult
{
    public string Token { get; set; } = string.Empty;
    public string Refresh { get; set; } = string.Empty;
    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }
}