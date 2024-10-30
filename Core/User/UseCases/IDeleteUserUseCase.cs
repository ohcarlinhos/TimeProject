using Shared.General;

namespace Core.User.UseCases;

public interface IDeleteUserUseCase
{
    Task<Result<bool>> Handle(int id);
}