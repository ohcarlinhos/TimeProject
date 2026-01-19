using TimeProject.Domain.Entities;

namespace TimeProject.Infrastructure.Database.Entities;

public class Minute : IMinute
{
    public int MinuteId { get; set; }
    public DateTimeOffset Date { get; set; }
    public int Total { get; set; }
    public int? RecordId { get; set; }
    public int? SessionId { get; set; }
    public int? CategoryId { get; set; }
    public int UserId { get; set; }

    public Record? Record { get; set; }
}