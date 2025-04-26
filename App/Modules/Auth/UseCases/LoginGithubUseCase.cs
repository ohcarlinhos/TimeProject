using Core.User.UseCases;
using App.Infrastructure.Errors;
using App.Infrastructure.Interfaces;
using Core.Auth.UseCases;
using Octokit;
using Shared.Auth;
using Shared.General;
using Shared.User;

namespace App.Modules.Auth.UseCases;

public class LoginGithubUseCase(
    IJwtService jwtService,
    IGetUserByOAtuhProviderIdUseCase getUserByOAtuhProviderIdUseCase,
    ICreateUserByGhUserUseCase createUserByGhUserUseCase
)
    : ILoginGithubUseCase
{
    public async Task<Result<JwtData>> Handle(LoginGithubDto dto)
    {
        var result = new Result<JwtData>();

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
                return result.SetData(jwtService.Generate(getUserByPIdResult.Data));
            }

            var emailList = await client.User.Email.GetAll();

            var createUserResult = await createUserByGhUserUseCase
                .Handle(
                    new CreateUserGhDto
                        { Name = userFromProvider.Name, UserProviderId = userFromProvider.Id.ToString() },
                    emailList.Select(e => new EmailGh(e.Email, e.Primary, e.Verified))
                );

            return createUserResult is { Data: not null }
                ? result.SetData(jwtService.Generate(createUserResult.Data))
                : result.SetError(createUserResult.Message);
        }
        catch
        {
            return result.SetError(AuthMessageErrors.AuthProviderError);
        }
    }
}