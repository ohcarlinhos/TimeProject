using TimeProject.Infrastructure.Entities;

namespace TimeProject.Application.UseCases.TimePeriod.Utils;

public interface ITimePeriodCutUtil
{
    Period Handle(Period entity, DateTime initDate, DateTime endDate);
    IList<Period> Handle(IList<Period> list, DateTime initDate, DateTime endDate);
}