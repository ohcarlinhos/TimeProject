using Octokit;
using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.UseCases.CustomLogs;
using TimeProject.Domain.UseCases.Logins;
using TimeProject.Domain.UseCases.Users;
using TimeProject.Domain.RemoveDependencies.Dtos.Auth;
using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.Interfaces;
using TimeProject.Infrastructure.ObjectValues.Users;

namespace TimeProject.Application.UseCases.Auth;

public class LoginGithubUseCase(
    IJwtHandler jwtHandler,
    IGetUserByOAtuhProviderIdUseCase getUserByOAtuhProviderIdUseCase,
    ICreateUserByGhUserUseCase createUserByGhUserUseCase,
    ICreateUserAccessLogUseCase createUserAccessLogUseCase
)
    : ILoginGithubUseCase
{
    public async Task<ICustomResult<IJwtResult>> Handle(ILoginGithubDto dto, IUserAccessLog ac)
    {
        var result = new CustomResult<IJwtResult>();

        try
        {
            var client = new GitHubClient(new ProductHeaderValue("RMTA"))
            {
                Credentials = new Credentials(dto.AccessToken, AuthenticationType.Bearer)
            };

            var userFromProvider = await client.User.Current();
            var getUserByPIdResult =
                getUserByOAtuhProviderIdUseCase.Handle("github", userFromProvider.Id.ToString());

            if (getUserByPIdResult is { Data: not null })
            {
                ac.UserId = getUserByPIdResult.Data.Id;
                createUserAccessLogUseCase.Handle(ac);
                return result.SetData(jwtHandler.Generate(getUserByPIdResult.Data));
            }

            var emailList = await client.User.Email.GetAll();

            var createUserResult = createUserByGhUserUseCase
                .Handle(
                    new CreateUserOAtuhDto
                        { Name = userFromProvider.Name, UserProviderId = userFromProvider.Id.ToString() },
                    emailList.Select(e => new EmailGh(e.Email, e.Primary, e.Verified))
                );


            var createIsSuccess = createUserResult is { Data: not null };

            if (!createIsSuccess) result.SetError(createUserResult.Message);

            ac.UserId = createUserResult.Data!.Id;
            createUserAccessLogUseCase.Handle(ac);

            return result.SetData(jwtHandler.Generate(createUserResult.Data));
        }
        catch
        {
            return result.SetError(AuthMessageErrors.AuthProviderError);
        }
    }
}