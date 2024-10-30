using Core.User;
using Core.User.UseCases;
using App.Infra.Errors;
using Entities;
using Shared.General;

namespace App.Modules.User.UseCases;

public class GetUserByEmailUseCase(IUserRepository repo) : IGetUserByEmailUseCase
{
    public async Task<Result<UserEntity>> Handle(string email)
    {
        var result = new Result<UserEntity>();
        var user = await repo.FindByEmail(email);

        return user == null ? result.SetError(UserMessageErrors.NotFound) : result.SetData(user);
    }
}