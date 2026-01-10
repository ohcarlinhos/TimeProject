using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.User;
using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.User;

public class DisableUserUseCase(IUserRepository repo) : IDisableUserUseCase
{
    public async Task<ICustomResult<bool>> Handle(int id, DisableUserDto dto)
    {
        var result = new CustomResult<bool>();
        var user = await repo.FindById(id);

        if (user == null)
            return result.SetError(UserMessageErrors.NotFound);

        user.IsActive = dto.IsActive;
        await repo.Update(user);

        result.Data = user.IsActive;

        return result;
    }
}