using API.Core.TimeRecord.Utils;
using AutoMapper;
using Shared.TimePeriod;

namespace API.Modules.TimeRecord.Utils;

public class TimeRecordMapDataUtil(IMapper mapper) : ITimeRecordMapDataUtil
{
    public IEnumerable<TimeRecordHistoryDayMap> Handle(IEnumerable<TimeRecordHistoryDay> entity)
    {
        return mapper.Map<IEnumerable<TimeRecordHistoryDay>, IEnumerable<TimeRecordHistoryDayMap>>(entity);
    }
}