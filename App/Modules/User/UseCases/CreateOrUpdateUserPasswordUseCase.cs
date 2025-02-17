using App.Infrastructure.Errors;
using Core.User.UseCases;
using Core.User.Repositories;
using Entities;
using Shared.General;
using Shared.User;

namespace App.Modules.User.UseCases;

public class CreateOrUpdateUserPasswordUseCase(IUserPasswordRepository repository) : ICreateOrUpdateUserPasswordUseCase
{
    public async Task<Result<bool>> Handle(int userId, CreatePasswordDto dto)
    {
        return await _handle(userId, dto.Password);
    }

    public async Task<Result<bool>> Handle(int userId, UpdatePasswordDto dto)
    {
        return await _handle(userId, dto.Password, dto.OldPassword);
    }

    private async Task<Result<bool>> _handle(int userId, string password, string oldPassword = "")
    {
        var result = new Result<bool>();
        var entity = await repository.FindByUserId(userId);

        if (entity != null && !string.IsNullOrEmpty(oldPassword))
        {
            if (BCrypt.Net.BCrypt.Verify(oldPassword, entity.Password) == false)
            {
                return result.SetError(UserMessageErrors.DifferentPassword);
            }

            entity.Password = BCrypt.Net.BCrypt.HashPassword(password);
            await repository.Update(entity);
        }
        else
        {
            await repository.Create(new UserPasswordEntity
            {
                UserId = userId,
                Password = BCrypt.Net.BCrypt.HashPassword(password)
            });
        }

        result.Data = true;
        return result;
    }
}