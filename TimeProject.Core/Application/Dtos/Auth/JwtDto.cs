namespace TimeProject.Core.Application.Dtos.Auth;

public class JwtDto
{
    public string Token { get; set; } = string.Empty;
    public string Refresh { get; set; } = string.Empty;
    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }
}