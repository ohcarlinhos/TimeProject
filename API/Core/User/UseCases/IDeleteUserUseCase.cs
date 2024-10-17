using Shared.General;

namespace API.Core.User.UseCases;

public interface IDeleteUserUseCase
{
    Task<Result<bool>> Handle(int id);
}