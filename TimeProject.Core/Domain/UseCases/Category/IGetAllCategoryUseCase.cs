using TimeProject.Core.RemoveDependencies.Dtos.Category;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Core.Domain.UseCases.Category;

public interface IGetAllCategoryUseCase
{
    Result<List<CategoryOutDto>> Handle(int userId, bool onlyWithData);
}