using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Infrastructure.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Users;
using TimeProject.Domain.Dtos.Users;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.ObjectValues.Users;

namespace TimeProject.Application.UseCases.Users;

public class DisableUserUseCase(IUserRepository repository) : IDisableUserUseCase
{
    public ICustomResult<bool> Handle(int id, IDisableUserDto dto)
    {
        var result = new CustomResult<bool>();
        var user = repository.FindById(id);

        if (user == null)
            return result.SetError(UserMessageErrors.NotFound);

        user.IsActive = dto.IsActive;
        repository.Update(user);

        result.Data = user.IsActive;

        return result;
    }
}