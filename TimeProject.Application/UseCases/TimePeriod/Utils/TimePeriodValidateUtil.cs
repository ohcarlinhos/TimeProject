using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Core.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Core.RemoveDependencies.General;
using TimeProject.Core.Domain.Utils;

namespace TimeProject.Application.UseCases.TimePeriod.Utils;

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