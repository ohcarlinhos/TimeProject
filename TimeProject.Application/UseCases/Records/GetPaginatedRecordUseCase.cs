using TimeProject.Application.ObjectValues;
using TimeProject.Domain.RemoveDependencies.Dtos.Record;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Records;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.RemoveDependencies.General.Pagination;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.Utils.Interfaces;

namespace TimeProject.Application.UseCases.Records;

public class GetPaginatedRecordUseCase(IRecordRepository repo, IRecordMapDataUtil mapDataUtil)
    : IGetPaginatedRecordUseCase
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