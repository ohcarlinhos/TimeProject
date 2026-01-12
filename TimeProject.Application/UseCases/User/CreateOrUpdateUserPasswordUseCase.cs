using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.User;
using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.User;

public class CreateOrUpdateUserPasswordUseCase(IUserPasswordRepository userPasswordRepository)
    : ICreateOrUpdateUserPasswordUseCase
{
    public Task<ICustomResult<bool>> Handle(int userId, CreatePasswordDto dto)
    {
        return _handle(userId, dto.Password);
    }

    public Task<ICustomResult<bool>> Handle(int userId, UpdatePasswordDto dto)
    {
        return _handle(userId, dto.Password, dto.OldPassword);
    }

    public Task<ICustomResult<bool>> Handle(int userId, UpdateByAdminPasswordDto dto)
    {
        return _handle(userId, dto.Password, "", true);
    }

    private async Task<ICustomResult<bool>> _handle(
        int userId,
        string password,
        string oldPassword = "",
        bool skipOldPasswordCompare = false
    )
    {
        var result = new CustomResult<bool>();
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
            await userPasswordRepository.Create(new UserPassword
            {
                UserId = userId,
                Password = BCrypt.Net.BCrypt.HashPassword(password)
            });
        }

        result.Data = true;
        return result;
    }
}