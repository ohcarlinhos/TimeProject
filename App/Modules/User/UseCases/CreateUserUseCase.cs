using Core.User;
using Core.User.UseCases;
using Core.User.Utils;
using App.Database;
using App.Infrastructure.Errors;
using App.Infrastructure.Interfaces;
using Entities;
using Shared.General;
using Shared.User;

namespace App.Modules.User.UseCases;

public class CreateUserUseCase(ProjectContext db, IUserRepository repo, IUserMapDataUtil mapper, IHookHandler hook)
    : ICreateUserUseCase
{
    public async Task<Result<UserMap>> Handle(CreateUserDto dto)
    {
        var result = new Result<UserMap>();
        var emailAvailable = await repo.EmailIsAvailable(dto.Email);

        if (emailAvailable == false)
        {
            result.Message = UserMessageErrors.EmailAlreadyInUse;
            result.HasError = true;
            return result;
        }

        var entity = await repo
            .Create(new UserEntity()
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            });
        await db.SaveChangesAsync();

        result.Data = mapper.Handle(entity);

        return result;
    }
}