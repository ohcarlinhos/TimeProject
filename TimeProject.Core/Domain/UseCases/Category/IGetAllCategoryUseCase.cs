using TimeProject.Core.Application.Dtos.Category;
using TimeProject.Core.Application.General;

namespace TimeProject.Core.Domain.UseCases.Category;

public interface IGetAllCategoryUseCase
{
    Result<List<CategoryOutDto>> Handle(int userId, bool onlyWithData);
}