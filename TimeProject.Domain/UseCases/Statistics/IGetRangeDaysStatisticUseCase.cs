using TimeProject.Domain.RemoveDependencies.Dtos.Statistic;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Statistics;

public interface IGetRangeDaysStatisticUseCase
{
    public ICustomResult<IRangeStatistic> Handle(int userId, DateTime? start = null, DateTime? end = null,
        int? recordId = null, bool skipRangeProgress = false);

    public ICustomResult<IRangeStatisticsWithDays> Handle(int userId, DateTime start, DateTime end);
}