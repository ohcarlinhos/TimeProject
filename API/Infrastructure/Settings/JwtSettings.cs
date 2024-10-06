namespace API.Infrastructure.Settings;

public class JwtSettings
{
    public string Secret { get; set; } = null!;
    public int ExpiresAt { get; set; }
}