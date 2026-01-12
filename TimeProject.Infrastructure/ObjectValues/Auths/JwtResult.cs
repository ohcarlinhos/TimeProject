using TimeProject.Domain.Dtos.Auths;

namespace TimeProject.Infrastructure.ObjectValues.Pagination.Auths;

public class JwtResult : IJwtResult
{
    public string Token { get; set; } = string.Empty;
    public string Refresh { get; set; } = string.Empty;
    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }
}