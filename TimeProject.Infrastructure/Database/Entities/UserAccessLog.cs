using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities.Enums;

namespace TimeProject.Infrastructure.Database.Entities;

public class UserAccessLog : IUserAccessLog
{
    public int Id { get; set; }
    public int UserId { get; set; }

    public string IpAddress { get; set; } = string.Empty;
    public string UserAgent { get; set; } = string.Empty;

    public AccessType AccessType { get; set; }
    public string Provider { get; set; } = "";

    public DateTime AccessAt { get; set; }
}