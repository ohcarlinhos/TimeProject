using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Core.RemoveDependencies.Dtos.User;
using TimeProject.Core.RemoveDependencies.General;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.Repositories;
using TimeProject.Core.Domain.UseCases.User;

namespace TimeProject.Application.UseCases.User;

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