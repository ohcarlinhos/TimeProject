using TimeProject.Domain.ObjectValues;
using TimeProject.Domain.Dtos.Categories;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Categories;

public interface IGetPaginatedCategoryUseCase
{
    ICustomResult<IPagination<ICategoryOutDto>> Handle(IPaginationQuery paginationQuery, int userId);
}