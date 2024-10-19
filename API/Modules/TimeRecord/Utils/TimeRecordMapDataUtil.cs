using API.Core.TimeRecord.Utils;
using AutoMapper;
using Entities;
using Shared.TimePeriod;
using Shared.TimeRecord;

namespace API.Modules.TimeRecord.Utils;

public class TimeRecordMapDataUtil(IMapper mapper) : ITimeRecordMapDataUtil
{
    public IEnumerable<TimeRecordHistoryDayMap> Handle(IEnumerable<TimeRecordHistoryDay> entity)
    {
        return mapper.Map<IEnumerable<TimeRecordHistoryDay>, IEnumerable<TimeRecordHistoryDayMap>>(entity);
    }

    public TimeRecordMap Handle(TimeRecordEntity entity)
    {
        return mapper.Map<TimeRecordEntity, TimeRecordMap>(entity);
    }

    public IEnumerable<TimeRecordMap> Handle(IEnumerable<TimeRecordEntity> entities)
    {
        return mapper.Map<IEnumerable<TimeRecordEntity>, IEnumerable<TimeRecordMap>>(entities);
    }

}