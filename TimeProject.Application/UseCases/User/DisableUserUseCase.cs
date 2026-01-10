using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Core.Domain.Repositories;
using TimeProject.Core.Domain.UseCases.User;
using TimeProject.Core.RemoveDependencies.Dtos.User;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Application.UseCases.User;

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