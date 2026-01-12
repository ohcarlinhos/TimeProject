using TimeProject.Domain.Entities;
using TimeProject.Domain.Dtos.Categories;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Categories;

public interface ICreateCategoryUseCase
{
    ICustomResult<ICategory> Handle(ICategoryDto dto, int userId);
}