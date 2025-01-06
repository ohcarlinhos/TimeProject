using Core.User;
using Core.User.UseCases;
using App.Infrastructure.Errors;
using Shared.General;
using Shared.User;

namespace App.Modules.User.UseCases;

public class DisableUserUseCase(IUserRepository repo): IDisableUserUseCase
{
    public async Task<Result<bool>> Handle(int id, DisableUserDto dto)
    {
        var result = new Result<bool>();
        var user = await repo.FindById(id);

        if (user == null)
            return result.SetError(UserMessageErrors.NotFound);

        user.IsActive = dto.IsActive;
        await repo.Update(user);

        result.Data = user.IsActive;

        return result;
    }
}