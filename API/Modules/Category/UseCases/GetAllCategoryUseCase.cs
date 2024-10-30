using Core.Category;
using Core.Category.UseCases;
using Core.Category.Utils;
using Shared.Category;
using Shared.General;

namespace API.Modules.Category.UseCases;

public class GetAllCategoryUseCase(ICategoryRepository repo, ICategoryMapDataUtil mapper) : IGetAllCategoryUseCase
{
    public Result<List<CategoryMap>> Handle(int userId, bool onlyWithData)
    {
        return new Result<List<CategoryMap>> { Data = mapper.Handle(repo.Index(userId, onlyWithData)) };
    }
}