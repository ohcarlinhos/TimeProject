using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.User;
using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.User;

public class CreateUserByGoogleUserUseCase(
    IUserRepository repository,
    IOAuthRepository oAuthRepository
) : ICreateUserByGoogleUserUseCase
{
    public async Task<ICustomResult<Infrastructure.Entities.User>> Handle(CreateUserOAtuhDto dto, string email)
    {
        var result = new CustomResult<Infrastructure.Entities.User>();

        if (string.IsNullOrEmpty(dto.UserProviderId)) return result.SetError(UserMessageErrors.OAuthWithoutProviderId);

        var userWithEmail = await repository.FindByEmail(email);

        if (userWithEmail != null)
        {
            await oAuthRepository.Create(new OAuth
            {
                UserId = userWithEmail.Id,
                Provider = "google",
                UserProviderId = dto.UserProviderId
            });

            return result.SetData(userWithEmail);
        }

        var userEntity = await repository
            .Create(new Infrastructure.Entities.User
            {
                Name = dto.Name,
                Email = email,
                Utc = dto.Utc
            });

        await oAuthRepository.Create(new OAuth
        {
            UserId = userEntity.Id,
            Provider = "google",
            UserProviderId = dto.UserProviderId
        });

        return result.SetData(userEntity);
    }
}