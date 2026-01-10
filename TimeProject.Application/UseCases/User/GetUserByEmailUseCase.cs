using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.Repositories;
using TimeProject.Core.Domain.UseCases.User;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Application.UseCases.User;

public class GetUserByEmailUseCase(IUserRepository repo) : IGetUserByEmailUseCase
{
    public async Task<Result<UserEntity>> Handle(string email)
    {
        var result = new Result<UserEntity>();
        var user = await repo.FindByEmail(email);

        return user == null ? result.SetError(UserMessageErrors.NotFound) : result.SetData(user);
    }
}