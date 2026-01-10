using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.TimePeriod;
using TimeProject.Domain.Utils;
using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.RemoveDependencies.General.Pagination;

namespace TimeProject.Application.UseCases.TimePeriod;

public class GetPaginatedTimePeriodUseCase(ITimePeriodRepository repo, ITimePeriodMapDataUtil mapDataUtil)
    : IGetPaginatedTimePeriodUseCase
{
    public async Task<Result<Pagination<TimePeriodOutDto>>> Handle(int timeRecordId, int userId,
        PaginationQuery paginationQuery)
    {
        var totalItems = await repo.GetTotalItems(timeRecordId, paginationQuery, userId);
        var data = mapDataUtil.Handle(repo.Index(timeRecordId, userId, paginationQuery));

        return new Result<Pagination<TimePeriodOutDto>>
        {
            Data = Pagination<TimePeriodOutDto>.Handle(
                data,
                paginationQuery,
                totalItems
            )
        };
    }
}