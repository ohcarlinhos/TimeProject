using Shared.General;
using Shared.User;

namespace API.Core.User.UseCases;

public interface IGetUserUseCase
{
    Task<Result<UserMap>> Handle(int id);
}