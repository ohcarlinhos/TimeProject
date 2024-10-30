using Core.User;
using Core.User.UseCases;
using Core.User.Utils;
using API.Database;
using API.Infra.Errors;
using Entities;
using Shared.General;
using Shared.User;

namespace API.Modules.User.UseCases;

public class CreateUserUseCase(ProjectContext db, IUserRepository repo, IUserMapDataUtil mapper) : ICreateUserUseCase
{
    public async Task<Result<UserMap>> Handle(CreateUserDto dto)
    {
        var result = new Result<UserMap>();
        var registerCode = await db.RegisterCodes.FindAsync(dto.RegisterCode);

        if (registerCode == null || registerCode.IsUsed)
        {
            result.Message = UserMessageErrors.RegisterCodeIsNotAvailable;
            result.HasError = true;
            return result;
        }

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

        registerCode.IsUsed = true;
        registerCode.UserId = entity.Id;

        db.RegisterCodes.Update(registerCode);
        await db.SaveChangesAsync();

        result.Data = mapper.Handle(entity);

        return result;
    }
}