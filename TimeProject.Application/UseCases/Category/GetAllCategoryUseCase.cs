using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Category;
using TimeProject.Domain.Utils;
using TimeProject.Domain.RemoveDependencies.Dtos.Category;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.Category;

public class GetAllCategoryUseCase(ICategoryRepository repo, ICategoryMapDataUtil mapper) : IGetAllCategoryUseCase
{
    public ICustomResult<IList<CategoryOutDto>> Handle(int userId, bool onlyWithData)
    {
        return new CustomResult<IList<CategoryOutDto>> { Data = mapper.Handle(repo.Index(userId, onlyWithData)) };
    }
}