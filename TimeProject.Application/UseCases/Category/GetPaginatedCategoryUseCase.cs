using TimeProject.Domain.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Categories;
using TimeProject.Infrastructure.Utils.Interfaces;
using TimeProject.Domain.Dtos.Categories;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.ObjectValues;

namespace TimeProject.Application.UseCases.Category;

public class GetPaginatedCategoryUseCase(ICategoryRepository repo, ICategoryMapDataUtil mapper)
    : IGetPaginatedCategoryUseCase
{
    public ICustomResult<IPagination<ICategoryOutDto>> Handle(IPaginationQuery paginationQuery, int userId)
    {
        var data = mapper.Handle(repo.Index(paginationQuery, userId));
        var totalItems = repo.GetTotalItems(paginationQuery, userId);

        return new CustomResult<IPagination<ICategoryOutDto>>
            { Data = Pagination<ICategoryOutDto>.Handle(data, paginationQuery, totalItems) };
    }
}