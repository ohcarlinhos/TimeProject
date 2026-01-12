using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Category;

public interface IDeleteCategoryUseCase
{
    ICustomResult<bool> Handle(int id, int userId);
}