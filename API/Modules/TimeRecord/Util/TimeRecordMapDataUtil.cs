using API.Core.TimeRecord.Util;
using AutoMapper;
using Shared.TimePeriod;

namespace API.Modules.TimeRecord.Util;

public class TimeRecordMapDataUtil(IMapper mapper) : ITimeRecordMapDataUtil
{
    public IEnumerable<TimeRecordHistoryDayMap> Handle(IEnumerable<TimeRecordHistoryDay> entity)
    {
        return mapper.Map<IEnumerable<TimeRecordHistoryDay>, IEnumerable<TimeRecordHistoryDayMap>>(entity);
    }
}