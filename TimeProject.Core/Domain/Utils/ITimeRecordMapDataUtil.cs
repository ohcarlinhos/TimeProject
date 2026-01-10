using TimeProject.Core.Domain.Entities;
using TimeProject.Core.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Core.RemoveDependencies.Dtos.TimeRecord;

namespace TimeProject.Core.Domain.Utils;

public interface ITimeRecordMapDataUtil
{
    IEnumerable<TimeRecordHistoryDayOutDto> Handle(IEnumerable<TimeRecordHistoryDay> entity);

    TimeRecordOutDto Handle(TimeRecordEntity entity);

    IEnumerable<TimeRecordOutDto> Handle(IEnumerable<TimeRecordEntity> entities);
}