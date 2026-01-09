using TimeProject.Core.Application.Dtos.Statistic;
using TimeProject.Core.Application.General;

namespace TimeProject.Core.Domain.UseCases.Statistic;

public interface IGetRangeDaysStatisticUseCase
{
    public Task<Result<RangeStatistic>> Handle(int userId, DateTime? start = null, DateTime? end = null,
        int? timeRecordId = null, bool skipRangeProgress = false);

    public Task<Result<RangeStatisticsWithDays>> Handle(int userId, DateTime start, DateTime end);
}