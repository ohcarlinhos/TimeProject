using Shared.General;
using Shared.User;

namespace API.Core.User.UseCases;

public interface IUpdateUserPasswordByEmailUseCase
{
    Task<Result<UserMap>> Handle(string email, string password);
}