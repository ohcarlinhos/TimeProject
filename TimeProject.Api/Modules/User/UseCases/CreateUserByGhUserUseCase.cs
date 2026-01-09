using Core.Auth.Repositories;
using Core.User.Repositories;
using Core.User.UseCases;
using Entities;
using Shared.General;
using Shared.User;
using TimeProject.Api.Infrastructure.Errors;

namespace TimeProject.Api.Modules.User.UseCases;

public class CreateUserByGhUserUseCase(
    IUserRepository repository,
    IOAuthRepository oAuthRepository
) : ICreateUserByGhUserUseCase
{
    public async Task<Result<UserEntity>> Handle(CreateUserOAtuhDto dto, IEnumerable<EmailGh> emails)
    {
        var result = new Result<UserEntity>();

        if (string.IsNullOrEmpty(dto.UserProviderId)) return result.SetError(UserMessageErrors.OAuthWithoutProviderId);

        var filtredEmails = emails.Where(e => e.Verified).ToList();
        var primaryEmail = filtredEmails.FirstOrDefault(e => e.Primary);

        if (filtredEmails.Count != 0 && primaryEmail != null)
        {
            var userWithPrimaryEmail = await repository.FindByEmail(primaryEmail.Email);

            if (userWithPrimaryEmail != null)
            {
                await oAuthRepository.Create(new OAuthEntity
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

                await oAuthRepository.Create(new OAuthEntity
                {
                    UserId = userWithSecondaryEmail.Id,
                    Provider = "github",
                    UserProviderId = dto.UserProviderId
                });

                return result.SetData(userWithSecondaryEmail);
            }
        }

        var userEntity = await repository
            .Create(new UserEntity
            {
                Name = dto.Name,
                Email = primaryEmail?.Email ?? "",
                Utc = dto.Utc
            });

        await oAuthRepository.Create(new OAuthEntity
        {
            UserId = userEntity.Id,
            Provider = "github",
            UserProviderId = dto.UserProviderId
        });

        return result.SetData(userEntity);
    }
}