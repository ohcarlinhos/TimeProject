using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Categories;
using TimeProject.Infrastructure.Utils.Interfaces;
using TimeProject.Domain.RemoveDependencies.Dtos.Category;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.Category;

public class GetAllCategoryUseCase(ICategoryRepository repo, ICategoryMapDataUtil mapper) : IGetAllCategoryUseCase
{
    public ICustomResult<IList<ICategoryOutDto>> Handle(int userId, bool onlyWithData)
    {
        return new CustomResult<IList<ICategoryOutDto>> { Data = mapper.Handle(repo.Index(userId, onlyWithData)) };
    }
}