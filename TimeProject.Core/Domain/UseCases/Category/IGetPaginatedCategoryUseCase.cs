using TimeProject.Core.Application.Dtos.Category;
using TimeProject.Core.Application.General;
using TimeProject.Core.Application.General.Pagination;

namespace TimeProject.Core.Domain.UseCases.Category;

public interface IGetPaginatedCategoryUseCase
{
    Task<Result<Pagination<CategoryOutDto>>> Handle(PaginationQuery paginationQuery, int userId);
}