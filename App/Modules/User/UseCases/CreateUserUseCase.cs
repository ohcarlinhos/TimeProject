using Core.User.UseCases;
using Core.User.Utils;
using App.Infrastructure.Errors;
using App.Infrastructure.Interfaces;
using Core.User.Repositories;
using Entities;
using Shared.General;
using Shared.User;

namespace App.Modules.User.UseCases;

public class CreateUserUseCase(
    IUserRepository repository,
    IUserMapDataUtil mapper,
    IHookHandler hookHandler,
    IJwtService jwtService,
    ICreateOrUpdateUserPasswordUseCase createUserPasswordUseCase
) : ICreateUserUseCase
{
    public async Task<Result<CreateUserResult>> Handle(CreateUserDto dto)
    {
        var result = new Result<CreateUserResult>();
        var emailAvailable = await repository.EmailIsAvailable(dto.Email);

        if (emailAvailable == false)
        {
            return result.SetError(UserMessageErrors.EmailAlreadyInUse);
        }

        var entity = await repository
            .Create(new UserEntity
            {
                Name = dto.Name,
                Email = dto.Email,
                Utc = dto.Utc
            });

        await createUserPasswordUseCase
            .Handle(entity.Id, new CreatePasswordDto { Password = dto.Password });

        result.Data = new CreateUserResult
        {
            User = mapper.Handle(entity),
            Jwt = jwtService.Generate(entity)
        };

        await hookHandler.Send(HookTo.Users,
            $"<b>{dto.Name}</b> acabou de criar uma conta com o email:\n<b>{dto.Email}</b>");

        return result;
    }
}