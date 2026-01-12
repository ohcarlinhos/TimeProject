using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.Category;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Category;

public interface ICreateCategoryUseCase
{
    ICustomResult<ICategory> Handle(ICategoryDto dto, int userId);
}