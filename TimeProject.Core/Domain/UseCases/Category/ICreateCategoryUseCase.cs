using TimeProject.Core.Application.Dtos.Category;
using TimeProject.Core.Application.General;
using TimeProject.Core.Domain.Entities;

namespace TimeProject.Core.Domain.UseCases.Category;

public interface ICreateCategoryUseCase
{
    Task<Result<CategoryEntity>> Handle(CategoryDto dto, int userId);
}