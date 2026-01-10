using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Category;
using TimeProject.Domain.Utils;
using TimeProject.Domain.RemoveDependencies.Dtos.Category;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Application.UseCases.Category;

public class GetAllCategoryUseCase(ICategoryRepository repo, ICategoryMapDataUtil mapper) : IGetAllCategoryUseCase
{
    public Result<List<CategoryOutDto>> Handle(int userId, bool onlyWithData)
    {
        return new Result<List<CategoryOutDto>> { Data = mapper.Handle(repo.Index(userId, onlyWithData)) };
    }
}