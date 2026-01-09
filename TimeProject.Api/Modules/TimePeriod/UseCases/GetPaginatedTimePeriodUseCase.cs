using TimeProject.Core.Application.Dtos.TimePeriod;
using TimeProject.Core.Application.General;
using TimeProject.Core.Application.General.Pagination;
using TimeProject.Core.Domain.Repositories;
using TimeProject.Core.Domain.UseCases.TimePeriod;
using TimeProject.Core.Domain.Utils;

namespace TimeProject.Api.Modules.TimePeriod.UseCases;

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