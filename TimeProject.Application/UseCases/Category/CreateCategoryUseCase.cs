using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Category;
using TimeProject.Domain.RemoveDependencies.Dtos.Category;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.Category;

public class CreateCategoryUseCase(ICategoryRepository repo) : ICreateCategoryUseCase
{
    public ICustomResult<ICategory> Handle(ICategoryDto dto, int userId)
    {
        var result = new CustomResult<ICategory>();
        var category = repo.FindByName(dto.Name, userId);

        if (category != null)
            return result.SetData(category);

        result.Data = repo.Create(new Infrastructure.Entities.Category
        {
            UserId = userId,
            Name = dto.Name
        });

        return result;
    }
}