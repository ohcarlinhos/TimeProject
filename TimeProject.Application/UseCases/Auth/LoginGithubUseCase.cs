using Octokit;
using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Api.Infrastructure.Interfaces;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Entities;
using TimeProject.Domain.UseCases.CustomLog;
using TimeProject.Domain.UseCases.Login;
using TimeProject.Domain.UseCases.User;
using TimeProject.Domain.RemoveDependencies.Dtos.Auth;
using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.Interfaces;

namespace TimeProject.Application.UseCases.Auth;

public class LoginGithubUseCase(
    IJwtHandler jwtHandler,
    IGetUserByOAtuhProviderIdUseCase getUserByOAtuhProviderIdUseCase,
    ICreateUserByGhUserUseCase createUserByGhUserUseCase,
    ICreateUserAccessLogUseCase createUserAccessLogUseCase
)
    : ILoginGithubUseCase
{
    public async Task<ICustomResult<JwtResult>> Handle(LoginGithubDto dto, UserAccessLog ac)
    {
        var result = new CustomResult<JwtResult>();

        try
        {
            var client = new GitHubClient(new ProductHeaderValue("RMTA"))
            {
                Credentials = new Credentials(dto.AccessToken, AuthenticationType.Bearer)
            };

            var userFromProvider = await client.User.Current();
            var getUserByPIdResult =
                await getUserByOAtuhProviderIdUseCase.Handle("github", userFromProvider.Id.ToString());

            if (getUserByPIdResult is { Data: not null })
            {
                ac.UserId = getUserByPIdResult.Data.Id;
                await createUserAccessLogUseCase.Handle(ac);
                return result.SetData(jwtHandler.Generate(getUserByPIdResult.Data));
            }

            var emailList = await client.User.Email.GetAll();

            var createUserResult = await createUserByGhUserUseCase
                .Handle(
                    new CreateUserOAtuhDto
                        { Name = userFromProvider.Name, UserProviderId = userFromProvider.Id.ToString() },
                    emailList.Select(e => new EmailGh(e.Email, e.Primary, e.Verified))
                );


            var createIsSuccess = createUserResult is { Data: not null };

            if (!createIsSuccess) result.SetError(createUserResult.Message);

            ac.UserId = createUserResult.Data!.Id;
            await createUserAccessLogUseCase.Handle(ac);

            return result.SetData(jwtHandler.Generate(createUserResult.Data));
        }
        catch
        {
            return result.SetError(AuthMessageErrors.AuthProviderError);
        }
    }
}