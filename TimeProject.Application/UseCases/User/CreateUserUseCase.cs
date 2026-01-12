using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.User;
using TimeProject.Domain.Utils;
using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.Interfaces;

namespace TimeProject.Application.UseCases.User;

public class CreateUserUseCase(
    IUserRepository repository,
    IUserMapDataUtil mapper,
    IHookHandler hookHandler,
    IJwtHandler jwtHandler,
    ICreateOrUpdateUserPasswordUseCase createUserPasswordUseCase
) : ICreateUserUseCase
{
    public async Task<ICustomResult<ICreateUserResult>> Handle(CreateUserDto dto)
    {
        var result = new CustomResult<ICreateUserResult>();
        var emailAvailable = await repository.EmailIsAvailable(dto.Email);

        if (emailAvailable == false) return result.SetError(UserMessageErrors.EmailAlreadyInUse);

        var entity = await repository
            .Create(new Infrastructure.Entities.User
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
            Jwt = jwtHandler.Generate(entity)
        };

        await hookHandler.Send(HookTo.Users,
            $"<b>{dto.Name}</b> acabou de criar uma conta com o email:\n<b>{dto.Email}</b>");

        return result;
    }
}