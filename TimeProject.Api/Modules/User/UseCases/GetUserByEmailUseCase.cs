using Core.User.Repositories;
using Core.User.UseCases;
using Entities;
using Shared.General;
using TimeProject.Api.Infrastructure.Errors;

namespace TimeProject.Api.Modules.User.UseCases;

public class GetUserByEmailUseCase(IUserRepository repo) : IGetUserByEmailUseCase
{
    public async Task<Result<UserEntity>> Handle(string email)
    {
        var result = new Result<UserEntity>();
        var user = await repo.FindByEmail(email);

        return user == null ? result.SetError(UserMessageErrors.NotFound) : result.SetData(user);
    }
}