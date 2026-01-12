using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Infrastructure.ObjectValues;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Users;
using TimeProject.Domain.Dtos.Users;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.Users;

public class CreateUserByGhUserUseCase(
    IUserRepository repository,
    IOAuthRepository oAuthRepository
) : ICreateUserByGhUserUseCase
{
    public ICustomResult<IUser> Handle(ICreateUserOAtuhDto dto, IEnumerable<EmailGh> emails)
    {
        var result = new CustomResult<IUser>();

        if (string.IsNullOrEmpty(dto.UserProviderId)) return result.SetError(UserMessageErrors.OAuthWithoutProviderId);

        var filtredEmails = emails.Where(e => e.Verified).ToList();
        var primaryEmail = filtredEmails.FirstOrDefault(e => e.Primary);

        if (filtredEmails.Count != 0 && primaryEmail != null)
        {
            var userWithPrimaryEmail = repository.FindByEmail(primaryEmail.Email);

            if (userWithPrimaryEmail != null)
            {
                oAuthRepository.Create(new OAuth
                {
                    UserId = userWithPrimaryEmail.Id,
                    Provider = "github",
                    UserProviderId = dto.UserProviderId
                });

                return result.SetData(userWithPrimaryEmail);
            }

            filtredEmails.Remove(primaryEmail);

            foreach (var secondaryEmail in filtredEmails)
            {
                var userWithSecondaryEmail = repository.FindByEmail(secondaryEmail.Email);
                if (userWithSecondaryEmail == null) continue;

                oAuthRepository.Create(new OAuth
                {
                    UserId = userWithSecondaryEmail.Id,
                    Provider = "github",
                    UserProviderId = dto.UserProviderId
                });

                return result.SetData(userWithSecondaryEmail);
            }
        }

        var userEntity = repository
            .Create(new Infrastructure.Database.Entities.User
            {
                Name = dto.Name,
                Email = primaryEmail?.Email ?? "",
                Utc = dto.Utc
            });

        oAuthRepository.Create(new OAuth
        {
            UserId = userEntity.Id,
            Provider = "github",
            UserProviderId = dto.UserProviderId
        });

        return result.SetData(userEntity);
    }
}