using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.Utils;

public interface ITimePeriodValidateUtil
{
    void ValidateStartAndEnd<T>(DateTime start, DateTime end, ICustomResult<T> customResult);

    bool HasMinSize(TimePeriodDto dto);
}