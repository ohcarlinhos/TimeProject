using Shared.TimePeriod;

namespace API.Core.TimeRecord.Util;

public interface ITimeRecordMapDataUtil
{
    public IEnumerable<TimeRecordHistoryDayMap> Handle(IEnumerable<TimeRecordHistoryDay> entity);
}