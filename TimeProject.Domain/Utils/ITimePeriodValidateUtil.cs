using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.Utils;

public interface ITimePeriodValidateUtil
{
    void ValidateStartAndEnd<T>(DateTime start, DateTime end, Result<T> result);

    bool HasMinSize(TimePeriodDto dto);
}