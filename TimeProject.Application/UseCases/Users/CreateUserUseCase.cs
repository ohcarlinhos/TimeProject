using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Domain.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Users;
using TimeProject.Infrastructure.Utils.Interfaces;
using TimeProject.Domain.Dtos.Users;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.Interfaces;
using TimeProject.Infrastructure.ObjectValues;
using TimeProject.Infrastructure.ObjectValues.Users;

namespace TimeProject.Application.UseCases.Users;

public class CreateUserUseCase(
    IUserRepository repository,
    IUserMapDataUtil mapper,
    IHookHandler hookHandler,
    IJwtHandler jwtHandler,
    ICreateOrUpdateUserPasswordUseCase createUserPasswordUseCase
) : ICreateUserUseCase
{
    public ICustomResult<ICreateUserResult> Handle(ICreateUserDto dto)
    {
        var result = new CustomResult<ICreateUserResult>();
        var emailAvailable = repository.EmailIsAvailable(dto.Email);

        if (emailAvailable == false) return result.SetError(UserMessageErrors.EmailAlreadyInUse);

        var entity = repository
            .Create(new Infrastructure.Database.Entities.User
            {
                Name = dto.Name,
                Email = dto.Email,
                Utc = dto.Utc
            });

        createUserPasswordUseCase
            .Handle(entity.Id, new CreatePasswordDto { Password = dto.Password });

        result.Data = new CreateUserResult
        {
            User = mapper.Handle(entity),
            Jwt = jwtHandler.Generate(entity)
        };

        hookHandler.Send(HookTo.Users,
            $"<b>{dto.Name}</b> acabou de criar uma conta com o email:\n<b>{dto.Email}</b>");

        return result;
    }
}