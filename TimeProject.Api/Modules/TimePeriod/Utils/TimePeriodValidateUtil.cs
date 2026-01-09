using Core.TimePeriod.Utils;
using Shared.General;
using Shared.TimePeriod;
using TimeProject.Api.Infrastructure.Errors;

namespace TimeProject.Api.Modules.TimePeriod.Utils;

public class TimePeriodValidateUtil : ITimePeriodValidateUtil
{
    public void ValidateStartAndEnd<T>(
        DateTime start,
        DateTime end,
        Result<T> result
    )
    {
        if (start.CompareTo(end) > 0)
            result.SetError(TimePeriodMessageErrors.EndDateIsBiggerThenStartDate);
    }

    public bool HasMinSize(TimePeriodDto dto)
    {
        var time = dto.End.Subtract(dto.Start);
        return time.TotalSeconds > 2;
    }
}