using TimeProject.Application.ObjectValues;
using TimeProject.Domain.RemoveDependencies.Dtos.Record;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.TimeRecord;
using TimeProject.Domain.Utils;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.RemoveDependencies.General.Pagination;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.TimeRecord;

public class GetPaginatedTimeRecordUseCase(IRecordRepository repo, ITimeRecordMapDataUtil mapDataUtil)
    : IGetPaginatedTimeRecordUseCase
{
    public ICustomResult<IPagination<IRecordOutDto>> Handle(PaginationQuery paginationQuery, int userId)
    {
        var result = repo.Index(paginationQuery, userId);

        return new CustomResult<IPagination<IRecordOutDto>>
        {
            Data = Pagination<IRecordOutDto>
                .Handle(mapDataUtil.Handle(result.Entities), paginationQuery, result.Count)
        };
    }
}