using TimeProject.Core.Application.Dtos.Category;
using TimeProject.Core.Application.General;
using TimeProject.Core.Application.General.Pagination;
using TimeProject.Core.Domain.Repositories;
using TimeProject.Core.Domain.UseCases.Category;
using TimeProject.Core.Domain.Utils;

namespace TimeProject.Api.Modules.Category.UseCases;

public class GetPaginatedCategoryUseCase(ICategoryRepository repo, ICategoryMapDataUtil mapper)
    : IGetPaginatedCategoryUseCase
{
    public async Task<Result<Pagination<CategoryOutDto>>> Handle(PaginationQuery paginationQuery, int userId)
    {
        var data = mapper.Handle(repo.Index(paginationQuery, userId));
        var totalItems = await repo.GetTotalItems(paginationQuery, userId);

        return new Result<Pagination<CategoryOutDto>>
            { Data = Pagination<CategoryOutDto>.Handle(data, paginationQuery, totalItems) };
    }
}