using TimeProject.Infrastructure.ObjectValues;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Users;
using TimeProject.Domain.Dtos.Users;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.Errors;

namespace TimeProject.Application.UseCases.Users;

public class CreateUserByGoogleUserUseCase(
    IUserRepository repository,
    IUserProviderRepository userProviderRepository
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
            userProviderRepository.Create(new UserProvider
            {
                UserId = userWithEmail.Id,
                Provider = "google",
                UserProviderId = dto.UserProviderId
            });

            return result.SetData(userWithEmail);
        }

        var userEntity = repository
            .Create(new Infrastructure.Database.Entities.User
            {
                Name = dto.Name,
                Email = email,
                Utc = dto.Utc
            });

        userProviderRepository.Create(new UserProvider
        {
            UserId = userEntity.Id,
            Provider = "google",
            UserProviderId = dto.UserProviderId
        });

        return result.SetData(userEntity);
    }
}