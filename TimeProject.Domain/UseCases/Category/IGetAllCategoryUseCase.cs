using TimeProject.Domain.RemoveDependencies.Dtos.Category;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Category;

public interface IGetAllCategoryUseCase
{
    ICustomResult<IList<CategoryOutDto>> Handle(int userId, bool onlyWithData);
}