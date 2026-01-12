using TimeProject.Domain.ObjectValues;
using TimeProject.Domain.RemoveDependencies.Dtos.Period;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Periods;

public interface IGetPaginatedPeriodUseCase
{
    ICustomResult<IPagination<IPeriodOutDto>> Handle(int recordId, int userId, IPaginationQuery paginationQuery);
}