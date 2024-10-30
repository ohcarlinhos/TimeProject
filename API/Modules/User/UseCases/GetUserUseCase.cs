using Core.User;
using Core.User.UseCases;
using Core.User.Utils;
using API.Infra.Errors;
using Shared.General;
using Shared.User;

namespace API.Modules.User.UseCases;

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