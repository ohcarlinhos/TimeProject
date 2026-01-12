using TimeProject.Infrastructure.Entities.Enums;

namespace TimeProject.Domain.Entities;

public interface IUserAccessLog
{
    int Id { get; set; }
    int UserId { get; set; }
    string IpAddress { get; set; }
    string UserAgent { get; set; }
    AccessType AccessType { get; set; }
    string Provider { get; set; }
    DateTime AccessAt { get; set; }
}