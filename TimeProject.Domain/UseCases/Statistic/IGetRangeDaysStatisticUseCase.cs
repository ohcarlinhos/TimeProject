using TimeProject.Domain.RemoveDependencies.Dtos.Statistic;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Statistic;

public interface IGetRangeDaysStatisticUseCase
{
    public Task<ICustomResult<RangeStatistic>> Handle(int userId, DateTime? start = null, DateTime? end = null,
        int? timeRecordId = null, bool skipRangeProgress = false);

    public Task<ICustomResult<RangeStatisticsWithDays>> Handle(int userId, DateTime start, DateTime end);
}