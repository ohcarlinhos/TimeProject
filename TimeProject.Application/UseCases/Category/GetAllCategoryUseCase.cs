using TimeProject.Core.Application.Dtos.Category;
using TimeProject.Core.Application.General;
using TimeProject.Core.Domain.Repositories;
using TimeProject.Core.Domain.UseCases.Category;
using TimeProject.Core.Domain.Utils;

namespace TimeProject.Application.UseCases.Category;

public class GetAllCategoryUseCase(ICategoryRepository repo, ICategoryMapDataUtil mapper) : IGetAllCategoryUseCase
{
    public Result<List<CategoryOutDto>> Handle(int userId, bool onlyWithData)
    {
        return new Result<List<CategoryOutDto>> { Data = mapper.Handle(repo.Index(userId, onlyWithData)) };
    }
}