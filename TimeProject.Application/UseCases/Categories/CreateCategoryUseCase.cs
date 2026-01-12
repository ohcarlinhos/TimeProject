using TimeProject.Infrastructure.ObjectValues.Pagination;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Categories;
using TimeProject.Domain.Dtos.Categories;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.Categories;

public class CreateCategoryUseCase(ICategoryRepository repository) : ICreateCategoryUseCase
{
    public ICustomResult<ICategory> Handle(ICategoryDto dto, int userId)
    {
        var result = new CustomResult<ICategory>();
        var category = repository.FindByName(dto.Name, userId);

        if (category != null)
            return result.SetData(category);

        result.Data = repository.Create(new Infrastructure.Database.Entities.Category
        {
            UserId = userId,
            Name = dto.Name
        });

        return result;
    }
}