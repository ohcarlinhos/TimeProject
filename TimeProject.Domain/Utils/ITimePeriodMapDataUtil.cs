using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;

namespace TimeProject.Domain.Utils;

public interface ITimePeriodMapDataUtil
{
    public ITimePeriodOutDto Handle(IPeriodRecord entity);
    public IList<ITimePeriodOutDto> Handle(IList<IPeriodRecord> entity);
}