using TimeProject.Core.Domain.Repositories;
using TimeProject.Core.Domain.UseCases.Category;
using TimeProject.Core.Domain.Utils;
using TimeProject.Core.RemoveDependencies.Dtos.Category;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Application.UseCases.Category;

public class GetAllCategoryUseCase(ICategoryRepository repo, ICategoryMapDataUtil mapper) : IGetAllCategoryUseCase
{
    public Result<List<CategoryOutDto>> Handle(int userId, bool onlyWithData)
    {
        return new Result<List<CategoryOutDto>> { Data = mapper.Handle(repo.Index(userId, onlyWithData)) };
    }
}