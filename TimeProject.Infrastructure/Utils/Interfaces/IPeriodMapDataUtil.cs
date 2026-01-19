using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Infrastructure.ObjectValues.Periods;

namespace TimeProject.Infrastructure.Utils.Interfaces;

public interface IPeriodMapDataUtil
{
    public PeriodOutDto Handle(Period entity);
    public IEnumerable<PeriodOutDto> Handle(IEnumerable<Period> entity);
}