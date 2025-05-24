using Core.User.UseCases;
using App.Infrastructure.Errors;
using App.Infrastructure.Interfaces;
using Core.Auth.UseCases;
using Core.Loogs.UserCases;
using Entities;
using Octokit;
using Shared.Auth;
using Shared.General;
using Shared.User;

namespace App.Modules.Auth.UseCases;

public class LoginGithubUseCase(
    IJwtService jwtService,
    IGetUserByOAtuhProviderIdUseCase getUserByOAtuhProviderIdUseCase,
    ICreateUserByGhUserUseCase createUserByGhUserUseCase,
    ICreateUserAccessLog createUserAccessLog
)
    : ILoginGithubUseCase
{
    public async Task<Result<JwtData>> Handle(LoginGithubDto dto, UserAccessLogEntity ac)
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
                ac.UserId = getUserByPIdResult.Data.Id;
                await createUserAccessLog.Handle(ac);
                return result.SetData(jwtService.Generate(getUserByPIdResult.Data));
            }

            var emailList = await client.User.Email.GetAll();

            var createUserResult = await createUserByGhUserUseCase
                .Handle(
                    new CreateUserOAtuhDto
                        { Name = userFromProvider.Name, UserProviderId = userFromProvider.Id.ToString() },
                    emailList.Select(e => new EmailGh(e.Email, e.Primary, e.Verified))
                );


            var createIsSuccess = createUserResult is { Data: not null };

            if (!createIsSuccess)
            {
                result.SetError(createUserResult.Message);
            }

            ac.UserId = createUserResult.Data!.Id;
            await createUserAccessLog.Handle(ac);

            return result.SetData(jwtService.Generate(createUserResult.Data));
        }
        catch
        {
            return result.SetError(AuthMessageErrors.AuthProviderError);
        }
    }
}