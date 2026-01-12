using TimeProject.Domain.Entities;

namespace TimeProject.Infrastructure.Entities;

public class OAuth : IOAuth
{
    public int UserId { get; set; }
    public string Provider { get; set; } = string.Empty;
    public string UserProviderId { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}