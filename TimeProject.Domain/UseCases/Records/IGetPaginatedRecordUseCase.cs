using TimeProject.Domain.ObjectValues;
using TimeProject.Domain.RemoveDependencies.Dtos.Record;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Records;

public interface IGetPaginatedRecordUseCase
{
    ICustomResult<IPagination<IRecordOutDto>> Handle(IPaginationQuery paginationQuery, int userId);
}