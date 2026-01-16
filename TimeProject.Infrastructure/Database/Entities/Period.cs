using System.ComponentModel.DataAnnotations.Schema;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities.Shared;

namespace TimeProject.Infrastructure.Database.Entities;

[Table("periods")]
public class Period : MultipleTimeRelationsEntity, IPeriod
{
    [Column("period_id")]
    public int Id { get; set; }
    
    [Column("start_period")]
    public DateTime Start { get; set; }
    [Column("end_period")]
    public DateTime End { get; set; }

    public Record? Record { get; set; }
    public Session? Session { get; set; }
}