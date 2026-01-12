using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.User;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.User;

public class GetUserByOAtuhProviderIdUseCase(IUserRepository repository, IOAuthRepository oAtuhRepository)
    : IGetUserByOAtuhProviderIdUseCase
{
    public async Task<ICustomResult<Infrastructure.Entities.User>> Handle(string provider, string id)
    {
        var result = new CustomResult<Infrastructure.Entities.User>();

        var userOAuth = await oAtuhRepository.FindByUserProviderId(provider, id);
        if (userOAuth == null) return result.SetError(UserMessageErrors.NotFound);

        var user = await repository.FindById(userOAuth.UserId);
        return user == null ? result.SetError(UserMessageErrors.NotFound) : result.SetData(user);
    }
}