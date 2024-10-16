using API.Core.User;
using API.Core.User.UseCases;
using API.Core.User.Utils;
using API.Database;
using API.Infra.Errors;
using Entities;
using Shared.General;
using Shared.User;

namespace API.Modules.User.UseCases;

public class CreateUserUseCase(ProjectContext db, IUserRepository repo, IUserMapDataUtil mapper): ICreateUserUseCase
{
    public async Task<Result<UserMap>> Handle(CreateUserDto dto)
    {
        var result = new Result<UserMap>();
        var registerCode = await db.RegisterCodes.FindAsync(dto.RegisterCode);

        if (registerCode == null || registerCode.IsUsed)
        {
            result.Message = UserErrors.RegisterCodeIsNotAvailable;
            result.HasError = true;
            return result;
        }

        var emailAvailable = await repo.EmailIsAvailable(dto.Email);

        if (emailAvailable == false)
        {
            result.Message = UserErrors.EmailAlreadyInUse;
            result.HasError = true;
            return result;
        }

        var hasPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        var entity = await repo
            .Create(new UserEntity()
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = hasPassword
            });

        registerCode.IsUsed = true;
        registerCode.UserId = entity.Id;

        db.RegisterCodes.Update(registerCode);
        await db.SaveChangesAsync();

        result.Data = mapper.Handle(entity);

        return result;
    }
}