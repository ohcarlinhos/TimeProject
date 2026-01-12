using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Domain.RemoveDependencies.Dtos.TimeRecord;

namespace TimeProject.Domain.Utils;

public interface ITimeRecordMapDataUtil
{
    IEnumerable<TimeRecordHistoryDayOutDto> Handle(IEnumerable<TimeRecordHistoryDay> entity);

    TimeRecordOutDto Handle(IRecord entity);

    IEnumerable<TimeRecordOutDto> Handle(IEnumerable<IRecord> entities);
}