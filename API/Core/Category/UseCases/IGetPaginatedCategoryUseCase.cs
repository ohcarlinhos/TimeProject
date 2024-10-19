using Shared.Category;
using Shared.General;
using Shared.General.Pagination;

namespace API.Core.Category.UseCases;

public interface IGetPaginatedCategoryUseCase
{
    Task<Result<Pagination<CategoryMap>>> Handle(PaginationQuery paginationQuery, int userId);
}