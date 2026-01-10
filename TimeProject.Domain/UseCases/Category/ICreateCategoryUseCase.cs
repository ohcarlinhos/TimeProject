using TimeProject.Domain.RemoveDependencies.Dtos.Category;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Category;

public interface ICreateCategoryUseCase
{
    Task<IResult<Entities.Category>> Handle(ICategoryDto dto, int userId);
}