using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Infrastructure.ObjectValues;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Users;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.Users;

public class GetUserByEmailUseCase(IUserRepository repository) : IGetUserByEmailUseCase
{
    public ICustomResult<IUser> Handle(string email)
    {
        var result = new CustomResult<IUser>();
        var user = repository.FindByEmail(email);

        return user == null ? result.SetError(UserMessageErrors.NotFound) : result.SetData(user);
    }
}