using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.RemoveDependencies.Dtos.Period;
using TimeProject.Domain.Utils;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.ObjectValues.Record;

namespace TimeProject.Application.UseCases.TimePeriod.Utils;

public class TimePeriodValidateUtil : ITimePeriodValidateUtil
{
    public void ValidateStartAndEnd<T>(
        DateTime start,
        DateTime end,
        ICustomResult<T> customResult
    )
    {
        if (start.CompareTo(end) > 0)
            customResult.SetError(TimePeriodMessageErrors.EndDateIsBiggerThenStartDate);
    }

    public bool HasMinSize(IPeriodDto dto)
    {
        var time = dto.End.Subtract(dto.Start);
        return time.TotalSeconds > 2;
    }
}