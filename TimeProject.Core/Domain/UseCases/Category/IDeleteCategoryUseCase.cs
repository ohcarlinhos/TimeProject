using TimeProject.Core.Application.General;

namespace TimeProject.Core.Domain.UseCases.Category;

public interface IDeleteCategoryUseCase
{
    Task<Result<bool>> Handle(int id, int userId);
}