using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Category;
using TimeProject.Domain.Utils;
using TimeProject.Domain.RemoveDependencies.Dtos.Category;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.RemoveDependencies.General.Pagination;

namespace TimeProject.Application.UseCases.Category;

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