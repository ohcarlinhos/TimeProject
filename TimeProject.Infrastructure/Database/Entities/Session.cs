using System.ComponentModel.DataAnnotations.Schema;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities.Shared;

namespace TimeProject.Infrastructure.Database.Entities;

[Table("sessions")]
public class Session : WithOwnerEntity, ISession
{
    [Column("session_id")] public int Id { get; set; }
    [Column("type")] public string? Type { get; set; } = string.Empty;
    [Column("date")] public DateTime Date { get; set; }
    [Column("session_from")] public string? From { get; set; } = string.Empty;
    [Column("record_id")] public int? RecordId { get; set; }
    [Column("category_id")] public int? CategoryId { get; set; }

    public Record? Record { get; set; } = null!;
    public IList<Period>? Periods { get; set; }
}