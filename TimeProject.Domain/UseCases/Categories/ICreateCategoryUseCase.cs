using TimeProject.Domain.Entities;
using TimeProject.Domain.Dtos.Categories;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Categories;

public interface ICreateCategoryUseCase
{
    ICustomResult<ICategoryOutDto> Handle(ICategoryDto dto, int userId);
}