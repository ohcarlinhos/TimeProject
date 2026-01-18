using System.ComponentModel.DataAnnotations.Schema;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities.Shared;

namespace TimeProject.Infrastructure.Database.Entities;

public class Period : IPeriod
{
    public int PeriodId { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public int? RecordId { get; set; }
    public int? SessionId { get; set; }
    public int? CategoryId { get; set; }
    public int UserId { get; set; }

    public Record? Record { get; set; }
    public Session? Session { get; set; }
}