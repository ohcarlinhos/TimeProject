using TimeProject.Domain.RemoveDependencies.Dtos.Category;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.RemoveDependencies.General.Pagination;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Category;

public interface IGetPaginatedCategoryUseCase
{
    Task<IResult<IPagination<CategoryOutDto>>> Handle(IPaginationQuery paginationQuery, int userId);
}