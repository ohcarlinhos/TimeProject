using Shared.TimePeriod;

namespace API.Core.TimeRecord.Utils;

public interface ITimeRecordMapDataUtil
{
    public IEnumerable<TimeRecordHistoryDayMap> Handle(IEnumerable<TimeRecordHistoryDay> entity);
}