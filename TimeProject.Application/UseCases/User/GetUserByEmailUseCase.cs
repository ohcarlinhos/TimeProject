using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.User;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.User;

public class GetUserByEmailUseCase(IUserRepository repo) : IGetUserByEmailUseCase
{
    public async Task<ICustomResult<Infrastructure.Entities.User>> Handle(string email)
    {
        var result = new CustomResult<Infrastructure.Entities.User>();
        var user = await repo.FindByEmail(email);

        return user == null ? result.SetError(UserMessageErrors.NotFound) : result.SetData(user);
    }
}