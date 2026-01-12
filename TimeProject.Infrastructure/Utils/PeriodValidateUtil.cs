using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Domain.Dtos.Periods;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.Utils.Interfaces;

namespace TimeProject.Infrastructure.Utils;

public class PeriodValidateUtil : IPeriodValidateUtil
{
    public void ValidateStartAndEnd<T>(
        DateTime start,
        DateTime end,
        ICustomResult<T> customResult
    )
    {
        if (start.CompareTo(end) > 0)
            customResult.SetError(PeriodMessageErrors.EndDateIsBiggerThenStartDate);
    }

    public bool HasMinSize(IPeriodDto dto)
    {
        var time = dto.End.Subtract(dto.Start);
        return time.TotalSeconds > 2;
    }
}