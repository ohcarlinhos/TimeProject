using System.ComponentModel.DataAnnotations.Schema;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities.Enums;
using TimeProject.Infrastructure.Database.Entities.Shared;

namespace TimeProject.Infrastructure.Database.Entities;

[Table("user_access_logs")]
public class UserAccessLog : WithOwnerEntity, IUserAccessLog
{
    [Column("log_id")] public int Id { get; set; }
    [Column("client_ip")] public string IpAddress { get; set; } = string.Empty;
    [Column("user_agent")] public string UserAgent { get; set; } = string.Empty;
    [Column("type")] public AccessType AccessType { get; set; }
    [Column("provider")] public string Provider { get; set; } = "";
    [Column("accessed_at")] public DateTime AccessAt { get; set; }
}