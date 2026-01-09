using Core.Auth.Repositories;
using Core.User.Repositories;
using Core.User.UseCases;
using Entities;
using Shared.General;
using Shared.User;
using TimeProject.Api.Infrastructure.Errors;

namespace TimeProject.Api.Modules.User.UseCases;

public class CreateUserByGoogleUserUseCase(
    IUserRepository repository,
    IOAuthRepository oAuthRepository
) : ICreateUserByGoogleUserUseCase
{
    public async Task<Result<UserEntity>> Handle(CreateUserOAtuhDto dto, string email)
    {
        var result = new Result<UserEntity>();

        if (string.IsNullOrEmpty(dto.UserProviderId)) return result.SetError(UserMessageErrors.OAuthWithoutProviderId);

        var userWithEmail = await repository.FindByEmail(email);

        if (userWithEmail != null)
        {
            await oAuthRepository.Create(new OAuthEntity
            {
                UserId = userWithEmail.Id,
                Provider = "google",
                UserProviderId = dto.UserProviderId
            });

            return result.SetData(userWithEmail);
        }

        var userEntity = await repository
            .Create(new UserEntity
            {
                Name = dto.Name,
                Email = email,
                Utc = dto.Utc
            });

        await oAuthRepository.Create(new OAuthEntity
        {
            UserId = userEntity.Id,
            Provider = "google",
            UserProviderId = dto.UserProviderId
        });

        return result.SetData(userEntity);
    }
}