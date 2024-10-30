using Core.User;
using Core.User.UseCases;
using Core.User.Utils;
using App.Infra.Errors;
using Shared.General;
using Shared.User;

namespace App.Modules.User.UseCases;

public class GetUserUseCase(IUserRepository repo, IUserMapDataUtil mapper) : IGetUserUseCase
{
    public async Task<Result<UserMap>> Handle(int id)
    {
        var result = new Result<UserMap>();
        var user = await repo.FindById(id);

        return user == null
            ? result.SetError(UserMessageErrors.NotFound)
            : result.SetData(mapper.Handle(user));
    }
}