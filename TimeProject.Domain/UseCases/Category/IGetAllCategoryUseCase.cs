using TimeProject.Domain.RemoveDependencies.Dtos.Category;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.Category;

public interface IGetAllCategoryUseCase
{
    Result<List<CategoryOutDto>> Handle(int userId, bool onlyWithData);
}