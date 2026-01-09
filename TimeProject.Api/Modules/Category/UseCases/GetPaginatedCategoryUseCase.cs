using Core.Category;
using Core.Category.UseCases;
using Core.Category.Utils;
using Shared.Category;
using Shared.General;
using Shared.General.Pagination;

namespace TimeProject.Api.Modules.Category.UseCases;

public class GetPaginatedCategoryUseCase(ICategoryRepository repo, ICategoryMapDataUtil mapper)
    : IGetPaginatedCategoryUseCase
{
    public async Task<Result<Pagination<CategoryMap>>> Handle(PaginationQuery paginationQuery, int userId)
    {
        var data = mapper.Handle(repo.Index(paginationQuery, userId));
        var totalItems = await repo.GetTotalItems(paginationQuery, userId);

        return new Result<Pagination<CategoryMap>>
            { Data = Pagination<CategoryMap>.Handle(data, paginationQuery, totalItems) };
    }
}