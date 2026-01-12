using TimeProject.Application.ObjectValues;
using TimeProject.Domain.RemoveDependencies.Dtos.Period;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.TimePeriod;
using TimeProject.Domain.Utils;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.RemoveDependencies.General.Pagination;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.TimePeriod;

public class GetPaginatedTimePeriodUseCase(IPeriodRecordRepository repo, ITimePeriodMapDataUtil mapDataUtil)
    : IGetPaginatedTimePeriodUseCase
{
    public ICustomResult<IPagination<IPeriodOutDto>> Handle(int timeRecordId, int userId,
        PaginationQuery paginationQuery)
    {
        var totalItems = repo.GetTotalItems(timeRecordId, paginationQuery, userId);
        var data = mapDataUtil.Handle(repo.Index(timeRecordId, userId, paginationQuery));

        return new CustomResult<IPagination<IPeriodOutDto>>
        {
            Data = Pagination<IPeriodOutDto>.Handle(
                data,
                paginationQuery,
                totalItems
            )
        };
    }
}