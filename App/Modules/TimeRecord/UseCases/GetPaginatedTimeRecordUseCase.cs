using Core.TimeRecord.Repositories;
using Core.TimeRecord.UseCases;
using Core.TimeRecord.Utils;
using Shared.General;
using Shared.General.Pagination;
using Shared.TimeRecord;

namespace App.Modules.TimeRecord.UseCases;

public class GetPaginatedTimeRecordUseCase(ITimeRecordRepository repo, ITimeRecordMapDataUtil mapDataUtil)
    : IGetPaginatedTimeRecordUseCase
{
    public async Task<Result<Pagination<TimeRecordMap>>> Handle(PaginationQuery paginationQuery, int userId)
    {
        var result = await repo.Index(paginationQuery, userId);

        return new Result<Pagination<TimeRecordMap>>
        {
            Data = Pagination<TimeRecordMap>.Handle(mapDataUtil.Handle(result.Entities), paginationQuery, result.Count)
        };
    }
}