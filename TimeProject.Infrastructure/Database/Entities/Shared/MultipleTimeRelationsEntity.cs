using System.ComponentModel.DataAnnotations.Schema;
using TimeProject.Domain.Entities.Shared;

namespace TimeProject.Infrastructure.Database.Entities.Shared;

public class MultipleTimeRelationsEntity : WithOwnerEntity, IMultipleTimeRelationsEntity
{
    [Column("record_id")] public int? RecordId { get; set; }
    [Column("session_id")] public int? SessionId { get; set; }
    [Column("category_id")] public int? CategoryId { get; set; }
}