using System.ComponentModel.DataAnnotations.Schema;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities.Shared;

namespace TimeProject.Infrastructure.Database.Entities;

[Table("minutes")]
public class Minute : MultipleTimeRelationsEntity, IMinute
{
    [Column("minute_id")] public int MinuteId { get; set; }
    [Column("date")] public DateTimeOffset Date { get; set; }
    [Column("total")] public int Total { get; set; }

    public Record? Record { get; set; }
}