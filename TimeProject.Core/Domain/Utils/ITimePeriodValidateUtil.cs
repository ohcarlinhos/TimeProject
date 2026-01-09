using TimeProject.Core.Application.Dtos.TimePeriod;
using TimeProject.Core.Application.General;

namespace TimeProject.Core.Domain.Utils;

public interface ITimePeriodValidateUtil
{
    void ValidateStartAndEnd<T>(DateTime start, DateTime end, Result<T> result);

    bool HasMinSize(TimePeriodDto dto);
}