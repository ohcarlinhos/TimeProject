using TimeProject.Core.Domain.Entities;
using TimeProject.Core.RemoveDependencies.Dtos.TimePeriod;

namespace TimeProject.Core.Domain.Utils;

public interface ITimePeriodMapDataUtil
{
    public TimePeriodOutDto Handle(TimePeriodEntity entity);
    public List<TimePeriodOutDto> Handle(List<TimePeriodEntity> entity);
}