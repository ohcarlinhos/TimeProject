using TimeProject.Core.RemoveDependencies.Dtos.Category;
using TimeProject.Core.RemoveDependencies.General;
using TimeProject.Core.RemoveDependencies.General.Pagination;

namespace TimeProject.Core.Domain.UseCases.Category;

public interface IGetPaginatedCategoryUseCase
{
    Task<Result<Pagination<CategoryOutDto>>> Handle(PaginationQuery paginationQuery, int userId);
}