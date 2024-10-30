using Shared.General;
using Shared.User;

namespace Core.User.UseCases;

public interface IGetUserUseCase
{
    Task<Result<UserMap>> Handle(int id);
}