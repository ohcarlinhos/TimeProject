using Core.User.Repositories;
using Core.User.UseCases;
using Shared.General;
using Shared.User;
using TimeProject.Api.Infrastructure.Errors;

namespace TimeProject.Api.Modules.User.UseCases;

public class DisableUserUseCase(IUserRepository repo) : IDisableUserUseCase
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