using Core.TimePeriod.Utils;
using App.Infra.Errors;
using Shared.General;
using Shared.TimePeriod;

namespace App.Modules.TimePeriod.Utils;

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