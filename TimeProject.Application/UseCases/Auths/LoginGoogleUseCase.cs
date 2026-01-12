using RestSharp;
using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Domain.UseCases.CustomLogs;
using TimeProject.Domain.UseCases.Logins;
using TimeProject.Domain.UseCases.Users;
using TimeProject.Domain.Dtos.Auths;
using TimeProject.Domain.Dtos.Users;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.Interfaces;
using TimeProject.Infrastructure.ObjectValues.Pagination;
using TimeProject.Infrastructure.ObjectValues.Pagination.Auths;
using TimeProject.Infrastructure.ObjectValues.Pagination.Users;

namespace TimeProject.Application.UseCases.Auths;

public class LoginGoogleUseCase(
    IJwtHandler jwtHandler,
    IGetUserByOAtuhProviderIdUseCase getUserByOAtuhProviderIdUseCase,
    ICreateUserByGoogleUserUseCase createUserByGoogleUserUseCase,
    ICreateUserAccessLogUseCase createUserAccessLogUseCase
)
    : ILoginGoogleUseCase
{
    private readonly RestClient _client = new("https://www.googleapis.com/oauth2/v1/userinfo");

    public async Task<ICustomResult<IJwtResult>> Handle(ILoginGoogleDto dto, IUserAccessLog ac)
    {
        var result = new CustomResult<IJwtResult>();

        try
        {
            var request = new RestRequest();
            request.AddHeader("Authorization", $"Bearer {dto.AccessToken}");

            var userFromProvider = (await _client.ExecuteAsync<LoginGoogleResponse>(request)).Data;

            if (userFromProvider is null) return result.SetError(AuthMessageErrors.AuthProviderError);

            var getUserByPIdResult = getUserByOAtuhProviderIdUseCase.Handle("google", userFromProvider.Id);

            if (getUserByPIdResult is { Data: not null })
            {
                ac.UserId = getUserByPIdResult.Data.Id;
                createUserAccessLogUseCase.Handle(ac);
                return result.SetData(jwtHandler.Generate(getUserByPIdResult.Data));
            }

            if (userFromProvider.VerifiedEmail == false)
                return result.SetError(UserMessageErrors.UserEmailProviderNotVerified);

            var createUserResult = createUserByGoogleUserUseCase
                .Handle(
                    new CreateUserOAtuhDto
                        { Name = userFromProvider.Name, UserProviderId = userFromProvider.Id },
                    userFromProvider.Email
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