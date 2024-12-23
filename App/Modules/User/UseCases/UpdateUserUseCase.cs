using Core.User;
using Core.User.UseCases;
using Core.User.Utils;
using App.Infra.Errors;
using Shared.General;
using Shared.User;

namespace App.Modules.User.UseCases;

public class UpdateUserUseCase(IUserRepository repo, IUserMapDataUtil mapper): IUpdateUserUseCase
{
    public async Task<Result<UserMap>> Handle(int id, UpdateUserDto dto)
    {
        return await _update(id, dto, null);
    }
    
    public async Task<Result<UserMap>> Handle(int id, UpdateUserDto dto, IUpdateUserOptions config)
    {
        return await _update(id, dto, config);
    }
    
    private async Task<Result<UserMap>> _update(int id, UpdateUserDto dto, IUpdateUserOptions? config)
    {
        var result = new Result<UserMap>();
        var user = await repo.FindById(id);

        if (user == null)
            return result.SetError(UserMessageErrors.NotFound);

        if (!string.IsNullOrWhiteSpace(dto.Email) && user.Email != dto.Email)
        {
            var emailAvailable = await repo.EmailIsAvailable(dto.Email);
            if (emailAvailable == false)
                return result.SetError(UserMessageErrors.EmailAlreadyInUse);

            user.Email = dto.Email;
            user.IsVerified = false;
        }

        if (!string.IsNullOrWhiteSpace(dto.Name) && user.Name != dto.Name)
            user.Name = dto.Name;

        if (!string.IsNullOrWhiteSpace(dto.Password))
        {
            if ((config == null || config.SkipOldPasswordCompare == false) &&
                BCrypt.Net.BCrypt.Verify(dto.OldPassword, user.Password) == false)
            {
                return result.SetError(UserMessageErrors.DifferentPassword);
            }

            user.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);
        }

        var entity = await repo.Update(user);

        result.Data = mapper.Handle(entity);
        return result;
    }
}