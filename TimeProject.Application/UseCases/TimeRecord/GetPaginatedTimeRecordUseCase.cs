using TimeProject.Core.Application.Dtos.TimeRecord;
using TimeProject.Core.Application.General;
using TimeProject.Core.Application.General.Pagination;
using TimeProject.Core.Domain.Repositories;
using TimeProject.Core.Domain.UseCases.TimeRecord;
using TimeProject.Core.Domain.Utils;

namespace TimeProject.Application.UseCases.TimeRecord;

public class GetPaginatedTimeRecordUseCase(ITimeRecordRepository repo, ITimeRecordMapDataUtil mapDataUtil)
    : IGetPaginatedTimeRecordUseCase
{
    public async Task<Result<Pagination<TimeRecordOutDto>>> Handle(PaginationQuery paginationQuery, int userId)
    {
        var result = await repo.Index(paginationQuery, userId);

        return new Result<Pagination<TimeRecordOutDto>>
        {
            Data = Pagination<TimeRecordOutDto>.Handle(mapDataUtil.Handle(result.Entities), paginationQuery,
                result.Count)
        };
    }
}