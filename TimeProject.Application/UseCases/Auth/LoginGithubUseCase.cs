using Octokit;
using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Api.Infrastructure.Interfaces;
using TimeProject.Core.RemoveDependencies.Dtos.Auth;
using TimeProject.Core.RemoveDependencies.Dtos.User;
using TimeProject.Core.RemoveDependencies.General;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.UseCases.CustomLog;
using TimeProject.Core.Domain.UseCases.Login;
using TimeProject.Core.Domain.UseCases.User;

namespace TimeProject.Application.UseCases.Auth;

public class LoginGithubUseCase(
    IJwtService jwtService,
    IGetUserByOAtuhProviderIdUseCase getUserByOAtuhProviderIdUseCase,
    ICreateUserByGhUserUseCase createUserByGhUserUseCase,
    ICreateUserAccessLogUseCase createUserAccessLogUseCase
)
    : ILoginGithubUseCase
{
    public async Task<Result<JwtDto>> Handle(LoginGithubDto dto, UserAccessLogEntity ac)
    {
        var result = new Result<JwtDto>();

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

            if (!createIsSuccess) result.SetError(createUserResult.Message);

            ac.UserId = createUserResult.Data!.Id;
            await createUserAccessLogUseCase.Handle(ac);

            return result.SetData(jwtService.Generate(createUserResult.Data));
        }
        catch
        {
            return result.SetError(AuthMessageErrors.AuthProviderError);
        }
    }
}