using TimeProject.Domain.Dtos.Periods;
using TimeProject.Domain.Shared;

namespace TimeProject.Infrastructure.Utils.Interfaces;

public interface IPeriodValidateUtil
{
    void ValidateStartAndEnd<T>(DateTime start, DateTime end, ICustomResult<T> customResult);

    bool HasMinSize(IPeriodData data);
}