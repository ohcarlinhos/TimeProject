using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.Repositories;
using TimeProject.Core.Domain.UseCases.User;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Application.UseCases.User;

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