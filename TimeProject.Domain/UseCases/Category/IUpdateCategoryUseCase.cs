using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.Category;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Category;

public interface IUpdateCategoryUseCase
{
    ICustomResult<ICategory> Handle(int id, ICategoryDto dto, int userId);
}