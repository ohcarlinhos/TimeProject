using Shared.Category;
using Shared.General;

namespace API.Core.Category.UseCases;

public interface IGetAllCategoryUseCase
{
    Result<List<CategoryMap>> Handle(int userId, bool onlyWithData);
}