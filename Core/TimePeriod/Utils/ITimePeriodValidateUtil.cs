using Shared.General;
using Shared.TimePeriod;

namespace Core.TimePeriod.Utils;

public interface ITimePeriodValidateUtil
{
    void ValidateStartAndEnd<T>(DateTime start, DateTime end, Result<T> result);

    bool HasMinSize(TimePeriodDto dto);
}