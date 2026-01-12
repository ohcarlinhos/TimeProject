using TimeProject.Domain.Dtos.Categories;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Categories;

public interface IGetAllCategoryUseCase
{
    ICustomResult<IList<ICategoryOutDto>> Handle(int userId, bool onlyWithData);
}