using Shared.General;
using Shared.User;

namespace Core.User.UseCases;

public interface IUpdateUserPasswordByEmailUseCase
{
    Task<Result<UserMap>> Handle(string email, string password);
}