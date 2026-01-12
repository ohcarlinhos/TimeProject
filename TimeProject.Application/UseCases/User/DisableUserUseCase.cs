using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.User;
using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.ObjectValues.Users;

namespace TimeProject.Application.UseCases.User;

public class DisableUserUseCase(IUserRepository repo) : IDisableUserUseCase
{
    public ICustomResult<bool> Handle(int id, IDisableUserDto dto)
    {
        var result = new CustomResult<bool>();
        var user = repo.FindById(id);

        if (user == null)
            return result.SetError(UserMessageErrors.NotFound);

        user.IsActive = dto.IsActive;
        repo.Update(user);

        result.Data = user.IsActive;

        return result;
    }
}