using Core.User;
using Core.User.UseCases;
using Core.User.Utils;
using App.Infra.Errors;
using Shared.General;
using Shared.User;

namespace App.Modules.User.UseCases;

public class UpdateUserPasswordByEmailUseCase(IUserRepository repo, IUserMapDataUtil mapper)
    : IUpdateUserPasswordByEmailUseCase
{
    public async Task<Result<UserMap>> Handle(string email, string password)
    {
        var result = new Result<UserMap>();
        var user = await repo.FindByEmail(email);

        if (user == null)
            return result.SetError(UserMessageErrors.NotFound);

        user.Password = BCrypt.Net.BCrypt.HashPassword(password);

        var entity = await repo.Update(user);
        result.Data = mapper.Handle(entity);
        return result;
    }
}