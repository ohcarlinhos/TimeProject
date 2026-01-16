using System.ComponentModel.DataAnnotations.Schema;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities.Shared;

namespace TimeProject.Infrastructure.Database.Entities;

[Table("user_providers")]
public class UserProvider : WithOwnerEntity, IUserProvider
{
    [Column("provider")] public string Provider { get; set; } = string.Empty;
    [Column("provider_external_id")] public string UserProviderId { get; set; } = string.Empty;
}