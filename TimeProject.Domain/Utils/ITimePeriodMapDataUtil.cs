using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;

namespace TimeProject.Domain.Utils;

public interface ITimePeriodMapDataUtil
{
    public TimePeriodOutDto Handle(TimePeriodEntity entity);
    public List<TimePeriodOutDto> Handle(List<TimePeriodEntity> entity);
}