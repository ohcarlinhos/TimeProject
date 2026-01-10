using TimeProject.Domain.RemoveDependencies.Dtos.Statistic;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.Statistic;

public interface IGetRangeDaysStatisticUseCase
{
    public Task<Result<RangeStatistic>> Handle(int userId, DateTime? start = null, DateTime? end = null,
        int? timeRecordId = null, bool skipRangeProgress = false);

    public Task<Result<RangeStatisticsWithDays>> Handle(int userId, DateTime start, DateTime end);
}