using TimeProject.Domain.RemoveDependencies.Dtos.Category;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Category;

public interface IGetAllCategoryUseCase
{
    IResult<IList<CategoryOutDto>> Handle(int userId, bool onlyWithData);
}