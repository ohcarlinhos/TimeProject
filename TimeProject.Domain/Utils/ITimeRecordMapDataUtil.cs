using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Domain.RemoveDependencies.Dtos.TimeRecord;

namespace TimeProject.Domain.Utils;

public interface ITimeRecordMapDataUtil
{
    IEnumerable<ITimeRecordHistoryDayOutDto> Handle(IEnumerable<TimeRecordHistoryDay> entity);

    ITimeRecordOutDto Handle(IRecord entity);

    IEnumerable<TimeRecordOutDto> Handle(IEnumerable<IRecord> entities);
}