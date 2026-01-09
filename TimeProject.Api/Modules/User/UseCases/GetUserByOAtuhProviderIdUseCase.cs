using Core.Auth.Repositories;
using Core.User.Repositories;
using Core.User.UseCases;
using Entities;
using Shared.General;
using TimeProject.Api.Infrastructure.Errors;

namespace TimeProject.Api.Modules.User.UseCases;

public class GetUserByOAtuhProviderIdUseCase(IUserRepository repository, IOAuthRepository oAtuhRepository)
    : IGetUserByOAtuhProviderIdUseCase
{
    public async Task<Result<UserEntity>> Handle(string provider, string id)
    {
        var result = new Result<UserEntity>();

        var userOAuth = await oAtuhRepository.FindByUserProviderId(provider, id);
        if (userOAuth == null) return result.SetError(UserMessageErrors.NotFound);

        var user = await repository.FindById(userOAuth.UserId);
        return user == null ? result.SetError(UserMessageErrors.NotFound) : result.SetData(user);
    }
}