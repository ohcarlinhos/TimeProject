using TimeProject.Application.ObjectValues;
using TimeProject.Domain.RemoveDependencies.Dtos.Period;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Periods;
using TimeProject.Infrastructure.Utils.Interfaces;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.RemoveDependencies.General.Pagination;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.Periods;

public class GetPaginatedPeriodUseCase(IPeriodRecordRepository repository, IPeriodMapDataUtil mapDataUtil)
    : IGetPaginatedPeriodUseCase
{
    public ICustomResult<IPagination<IPeriodOutDto>> Handle(int recordId, int userId,
        PaginationQuery paginationQuery)
    {
        var totalItems = repository.GetTotalItems(recordId, paginationQuery, userId);
        var data = mapDataUtil.Handle(repository.Index(recordId, userId, paginationQuery));

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