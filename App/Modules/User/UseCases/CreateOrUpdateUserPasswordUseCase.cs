using App.Infrastructure.Errors;
using Core.User.UseCases;
using Core.User.Repositories;
using Entities;
using Shared.General;
using Shared.User;

namespace App.Modules.User.UseCases;

public class CreateOrUpdateUserPasswordUseCase(IUserPasswordRepository userPasswordRepository)
    : ICreateOrUpdateUserPasswordUseCase
{
    public Task<Result<bool>> Handle(int userId, CreatePasswordDto dto)
    {
        return _handle(userId, dto.Password);
    }

    public Task<Result<bool>> Handle(int userId, UpdatePasswordDto dto)
    {
        return _handle(userId, dto.Password, dto.OldPassword);
    }

    public Task<Result<bool>> Handle(int userId, UpdateByAdminPasswordDto dto)
    {
        return _handle(userId, dto.Password, "", true);
    }

    private async Task<Result<bool>> _handle(
        int userId,
        string password,
        string oldPassword = "",
        bool skipOldPasswordCompare = false
    )
    {
        var result = new Result<bool>();
        var entity = await userPasswordRepository.FindByUserId(userId);

        if (entity != null && (!string.IsNullOrEmpty(oldPassword) || skipOldPasswordCompare))
        {
            if (skipOldPasswordCompare == false && BCrypt.Net.BCrypt.Verify(oldPassword, entity.Password) == false)
            {
                return result.SetError(UserMessageErrors.DifferentPassword);
            }

            entity.Password = BCrypt.Net.BCrypt.HashPassword(password);
            await userPasswordRepository.Update(entity);
        }
        else
        {
            await userPasswordRepository.Create(new UserPasswordEntity
            {
                UserId = userId,
                Password = BCrypt.Net.BCrypt.HashPassword(password)
            });
        }

        result.Data = true;
        return result;
    }
}