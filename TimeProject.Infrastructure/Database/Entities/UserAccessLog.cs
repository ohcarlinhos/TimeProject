using System.Net;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Entities.Enums;
using TimeProject.Infrastructure.Database.Entities.Enums;

namespace TimeProject.Infrastructure.Database.Entities;

public class UserAccessLog : IUserAccessLog
{
    public int LogId { get; set; }
    public IPAddress? ClientIp { get; set; }
    public string UserAgent { get; set; } = string.Empty;
    public int UserId { get; set; }
    public AccessType Type { get; set; }
    public ProviderType? Provider { get; set; }
    public DateTime AccessedAt { get; set; }
}