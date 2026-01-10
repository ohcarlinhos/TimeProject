using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.Utils;

public interface ITimePeriodValidateUtil
{
    void ValidateStartAndEnd<T>(DateTime start, DateTime end, CustomResult<T> customResult);

    bool HasMinSize(TimePeriodDto dto);
}