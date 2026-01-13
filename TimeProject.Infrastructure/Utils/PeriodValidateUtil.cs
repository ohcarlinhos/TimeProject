using TimeProject.Domain.Dtos.Periods;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.Errors;
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

    public bool HasMinSize(IPeriodData data)
    {
        var time = data.End.Subtract(data.Start);
        return time.TotalSeconds > 2;
    }
}