using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Category;

public interface IDeleteCategoryUseCase
{
    Task<IResult<bool>> Handle(int id, int userId);
}