using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Category;
using TimeProject.Infrastructure.Utils.Interfaces;
using TimeProject.Domain.RemoveDependencies.Dtos.Category;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.RemoveDependencies.General.Pagination;
using TimeProject.Domain.Shared;

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