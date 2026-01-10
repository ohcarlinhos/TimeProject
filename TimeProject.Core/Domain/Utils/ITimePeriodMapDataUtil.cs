using TimeProject.Core.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Core.Domain.Entities;

namespace TimeProject.Core.Domain.Utils;

public interface ITimePeriodMapDataUtil
{
    public TimePeriodOutDto Handle(TimePeriodEntity entity);
    public List<TimePeriodOutDto> Handle(List<TimePeriodEntity> entity);
}