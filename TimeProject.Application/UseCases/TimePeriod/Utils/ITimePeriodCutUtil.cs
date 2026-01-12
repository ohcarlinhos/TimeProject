using TimeProject.Infrastructure.Entities;

namespace TimeProject.Application.UseCases.TimePeriod.Utils;

public interface ITimePeriodCutUtil
{
    PeriodRecord Handle(PeriodRecord entity, DateTime initDate, DateTime endDate);
    IList<PeriodRecord> Handle(IList<PeriodRecord> list, DateTime initDate, DateTime endDate);
}