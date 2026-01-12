using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Infrastructure.ObjectValues.Pagination;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Users;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.Users;

public class GetUserByOAtuhProviderIdUseCase(IUserRepository repository, IOAuthRepository oAtuhRepository)
    : IGetUserByOAtuhProviderIdUseCase
{
    public ICustomResult<IUser> Handle(string provider, string id)
    {
        var result = new CustomResult<IUser>();

        var userOAuth = oAtuhRepository.FindByUserProviderId(provider, id);
        if (userOAuth == null) return result.SetError(UserMessageErrors.NotFound);

        var user = repository.FindById(userOAuth.UserId);
        return user == null ? result.SetError(UserMessageErrors.NotFound) : result.SetData(user);
    }
}