using System.ComponentModel.DataAnnotations.Schema;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities.Shared;

namespace TimeProject.Infrastructure.Database.Entities;

[Table("record_resumes")]
public class RecordMeta : WithOwnerEntity, IRecordMeta
{
    [Column("record_id")] public int RecordId { get; set; }
    [Column("formatted")] public string FormattedTime { get; set; } = string.Empty;
    [Column("seconds")] public double TimeOnSeconds { get; set; }
    [Column("first_date")] public DateTime? FirstTimeDate { get; set; }
    [Column("last_date")] public DateTime? LastTimeDate { get; set; }
    [Column("count")] public int TimeCount { get; set; }
}