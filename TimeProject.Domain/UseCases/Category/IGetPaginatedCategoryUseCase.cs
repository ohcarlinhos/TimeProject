using TimeProject.Domain.RemoveDependencies.Dtos.Category;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.RemoveDependencies.General.Pagination;

namespace TimeProject.Domain.UseCases.Category;

public interface IGetPaginatedCategoryUseCase
{
    Task<Result<Pagination<CategoryOutDto>>> Handle(PaginationQuery paginationQuery, int userId);
}