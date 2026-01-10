using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;

namespace TimeProject.Domain.Utils;

public interface ITimePeriodMapDataUtil
{
    public TimePeriodOutDto Handle(PeriodRecord entity);
    public List<TimePeriodOutDto> Handle(List<PeriodRecord> entity);
}