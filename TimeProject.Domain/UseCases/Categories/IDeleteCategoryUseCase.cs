using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Categories;

public interface IDeleteCategoryUseCase
{
    ICustomResult<bool> Handle(int id, int userId);
}