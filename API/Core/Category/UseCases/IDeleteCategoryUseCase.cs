using Shared.General;

namespace API.Core.Category.UseCases;

public interface IDeleteCategoryUseCase
{
    Task<Result<bool>> Handle(int id, int userId);
}