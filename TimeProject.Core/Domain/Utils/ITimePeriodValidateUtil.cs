using TimeProject.Core.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Core.Domain.Utils;

public interface ITimePeriodValidateUtil
{
    void ValidateStartAndEnd<T>(DateTime start, DateTime end, Result<T> result);

    bool HasMinSize(TimePeriodDto dto);
}