using Core.User;
using Core.User.UseCases;
using App.Infrastructure.Errors;
using Shared.General;

namespace App.Modules.User.UseCases;

public class SetIsVerifiedUserUseCase(IUserRepository repo) : ISetIsVerifiedUserUseCase
{
    public async Task<Result<bool>> Handle(int id, bool isVerified)
    {
        var result = new Result<bool>();
        var user = await repo.FindById(id);

        if (user == null)
            return result.SetError(UserMessageErrors.NotFound);

        user.IsVerified = isVerified;
        await repo.Update(user);

        result.Data = user.IsVerified;

        return result;
    }
}