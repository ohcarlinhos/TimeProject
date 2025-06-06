using Shared.General;
using Shared.Statistic;

namespace Core.Statistic.UseCases;

public interface IGetRangeDaysStatisticUseCase
{
    public Task<Result<RangeStatistic>> Handle(int userId, DateTime? start = null, DateTime? end = null,
        int? timeRecordId = null, bool skipRangeProgress = false);

    public Task<Result<RangeStatisticsWithDays>> Handle(int userId, DateTime start, DateTime end);
}