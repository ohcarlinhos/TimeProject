using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.User;
using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.User;

public class CreateUserByGhUserUseCase(
    IUserRepository repository,
    IOAuthRepository oAuthRepository
) : ICreateUserByGhUserUseCase
{
    public async Task<ICustomResult<Infrastructure.Entities.User>> Handle(CreateUserOAtuhDto dto, IEnumerable<EmailGh> emails)
    {
        var result = new CustomResult<Infrastructure.Entities.User>();

        if (string.IsNullOrEmpty(dto.UserProviderId)) return result.SetError(UserMessageErrors.OAuthWithoutProviderId);

        var filtredEmails = emails.Where(e => e.Verified).ToList();
        var primaryEmail = filtredEmails.FirstOrDefault(e => e.Primary);

        if (filtredEmails.Count != 0 && primaryEmail != null)
        {
            var userWithPrimaryEmail = await repository.FindByEmail(primaryEmail.Email);

            if (userWithPrimaryEmail != null)
            {
                await oAuthRepository.Create(new OAuth
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
                var userWithSecondaryEmail = await repository.FindByEmail(secondaryEmail.Email);
                if (userWithSecondaryEmail == null) continue;

                await oAuthRepository.Create(new OAuth
                {
                    UserId = userWithSecondaryEmail.Id,
                    Provider = "github",
                    UserProviderId = dto.UserProviderId
                });

                return result.SetData(userWithSecondaryEmail);
            }
        }

        var userEntity = await repository
            .Create(new Infrastructure.Entities.User
            {
                Name = dto.Name,
                Email = primaryEmail?.Email ?? "",
                Utc = dto.Utc
            });

        await oAuthRepository.Create(new OAuth
        {
            UserId = userEntity.Id,
            Provider = "github",
            UserProviderId = dto.UserProviderId
        });

        return result.SetData(userEntity);
    }
}