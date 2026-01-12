using TimeProject.Domain.Dtos.Periods;
using TimeProject.Domain.Dtos.Records;
using TimeProject.Infrastructure.Utils;

namespace TimeProject.Infrastructure.ObjectValues.Pagination.Sessions;

public class SessionOutDto : ISessionOutDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int RecordId { get; set; }

    public string? Type { get; set; }
    public string? From { get; set; }

    public IEnumerable<IPeriodOutDto>? Periods { get; set; }

    public string FormattedTime => TimeFormatUtil.StringFromPeriods(Periods);
}