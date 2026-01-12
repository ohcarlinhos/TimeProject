using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Users;
using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.ObjectValues.Users;

namespace TimeProject.Application.UseCases.User;

public class CreateUserByGoogleUserUseCase(
    IUserRepository repository,
    IOAuthRepository oAuthRepository
) : ICreateUserByGoogleUserUseCase
{
    public ICustomResult<IUser> Handle(ICreateUserOAtuhDto dto, string email)
    {
        var result = new CustomResult<IUser>();

        if (string.IsNullOrEmpty(dto.UserProviderId)) 
            return result.SetError(UserMessageErrors.OAuthWithoutProviderId);

        var userWithEmail = repository.FindByEmail(email);

        if (userWithEmail != null)
        {
            oAuthRepository.Create(new OAuth
            {
                UserId = userWithEmail.Id,
                Provider = "google",
                UserProviderId = dto.UserProviderId
            });

            return result.SetData(userWithEmail);
        }

        var userEntity = repository
            .Create(new Infrastructure.Entities.User
            {
                Name = dto.Name,
                Email = email,
                Utc = dto.Utc
            });

        oAuthRepository.Create(new OAuth
        {
            UserId = userEntity.Id,
            Provider = "google",
            UserProviderId = dto.UserProviderId
        });

        return result.SetData(userEntity);
    }
}