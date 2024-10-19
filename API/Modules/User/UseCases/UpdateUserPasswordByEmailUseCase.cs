using API.Core.User;
using API.Core.User.UseCases;
using API.Core.User.Utils;
using API.Infra.Errors;
using Shared.General;
using Shared.User;

namespace API.Modules.User.UseCases;

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