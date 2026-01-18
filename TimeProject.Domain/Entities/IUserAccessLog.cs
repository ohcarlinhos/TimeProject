using System.Net;
using TimeProject.Domain.Entities.Enums;
using TimeProject.Infrastructure.Database.Entities.Enums;

namespace TimeProject.Domain.Entities;

public interface IUserAccessLog
{
    int LogId { get; set; }
    int UserId { get; set; }
    IPAddress ClientIp { get; set; }
    string UserAgent { get; set; }
    AccessType Type { get; set; }
    ProviderType? Provider { get; set; }
    DateTime AccessedAt { get; set; }
}