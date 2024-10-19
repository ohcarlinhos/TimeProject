using Entities;
using Shared.TimePeriod;
using Shared.TimeRecord;

namespace API.Core.TimeRecord.Utils;

public interface ITimeRecordMapDataUtil
{
    IEnumerable<TimeRecordHistoryDayMap> Handle(IEnumerable<TimeRecordHistoryDay> entity);

    TimeRecordMap Handle(TimeRecordEntity entity);

    IEnumerable<TimeRecordMap> Handle(IEnumerable<TimeRecordEntity> entities);
}