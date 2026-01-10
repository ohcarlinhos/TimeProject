using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.Category;

public interface IDeleteCategoryUseCase
{
    Task<Result<bool>> Handle(int id, int userId);
}