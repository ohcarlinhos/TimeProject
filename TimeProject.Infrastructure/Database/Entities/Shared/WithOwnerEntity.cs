using System.ComponentModel.DataAnnotations.Schema;
using TimeProject.Domain.Entities.Shared;

namespace TimeProject.Infrastructure.Database.Entities.Shared;

public class WithOwnerEntity: BaseEntity, IWithOwnerEntity
{
    [Column("user_id")] public int UserId { get; set; }
}