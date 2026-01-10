using System.Text.Json.Serialization;
using RestSharp;
using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Api.Infrastructure.Interfaces;
using TimeProject.Domain.Entities;
using TimeProject.Domain.UseCases.CustomLog;
using TimeProject.Domain.UseCases.Login;
using TimeProject.Domain.UseCases.User;
using TimeProject.Domain.RemoveDependencies.Dtos.Auth;
using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Infrastructure.Interfaces;

namespace TimeProject.Application.UseCases.Auth;

public class LoginGoogleResponse
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Picture { get; set; }
    [JsonPropertyName("verified_email")] public bool VerifiedEmail { get; set; }
}

public class LoginGoogleUseCase(
    IJwtHandler jwtHandler,
    IGetUserByOAtuhProviderIdUseCase getUserByOAtuhProviderIdUseCase,
    ICreateUserByGoogleUserUseCase createUserByGoogleUserUseCase,
    ICreateUserAccessLogUseCase createUserAccessLogUseCase
)
    : ILoginGoogleUseCase
{
    private readonly RestClient _client = new("https://www.googleapis.com/oauth2/v1/userinfo");

    public async Task<Result<JwtResult>> Handle(LoginGoogleDto dto, UserAccessLogEntity ac)
    {
        var result = new Result<JwtResult>();

        try
        {
            var request = new RestRequest();
            request.AddHeader("Authorization", $"Bearer {dto.AccessToken}");

            var userFromProvider = (await _client.ExecuteAsync<LoginGoogleResponse>(request)).Data;

            if (userFromProvider is null) return result.SetError(AuthMessageErrors.AuthProviderError);

            var getUserByPIdResult = await getUserByOAtuhProviderIdUseCase.Handle("google", userFromProvider.Id);

            if (getUserByPIdResult is { Data: not null })
            {
                ac.UserId = getUserByPIdResult.Data.Id;
                await createUserAccessLogUseCase.Handle(ac);
                return result.SetData(jwtHandler.Generate(getUserByPIdResult.Data));
            }

            if (userFromProvider.VerifiedEmail == false)
                return result.SetError(UserMessageErrors.UserEmailProviderNotVerified);

            var createUserResult = await createUserByGoogleUserUseCase
                .Handle(
                    new CreateUserOAtuhDto
                        { Name = userFromProvider.Name, UserProviderId = userFromProvider.Id },
                    userFromProvider.Email
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