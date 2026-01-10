using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.Repositories;
using TimeProject.Core.Domain.UseCases.User;
using TimeProject.Core.RemoveDependencies.Dtos.User;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Application.UseCases.User;

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
                return result.SetError(UserMessageErrors.DifferentPassword);

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