using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.TimeRecord;
using TimeProject.Domain.Utils;
using TimeProject.Domain.RemoveDependencies.Dtos.TimeRecord;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.RemoveDependencies.General.Pagination;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.TimeRecord;

public class GetPaginatedTimeRecordUseCase(IRecordRepository repo, ITimeRecordMapDataUtil mapDataUtil)
    : IGetPaginatedTimeRecordUseCase
{
    public async Task<ICustomResult<IPagination<TimeRecordOutDto>>> Handle(PaginationQuery paginationQuery, int userId)
    {
        var result = await repo.Index(paginationQuery, userId);

        return new CustomResult<IPagination<TimeRecordOutDto>>
        {
            Data = Pagination<TimeRecordOutDto>.Handle(mapDataUtil.Handle(result.Entities), paginationQuery,
                result.Count)
        };
    }
}