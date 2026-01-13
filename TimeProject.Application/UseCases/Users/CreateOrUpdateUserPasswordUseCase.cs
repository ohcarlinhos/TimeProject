using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Infrastructure.ObjectValues;
using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Users;
using TimeProject.Domain.Dtos.Users;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.Users;

public class CreateOrUpdateUserPasswordUseCase(IUserPasswordRepository userPasswordRepository)
    : ICreateOrUpdateUserPasswordUseCase
{
    public ICustomResult<bool> Handle(int userId, ICreatePasswordDto dto)
    {
        return _handle(userId, dto.Password);
    }

    public ICustomResult<bool> Handle(int userId, IUpdatePasswordDto dto)
    {
        return _handle(userId, dto.Password, dto.OldPassword);
    }

    public ICustomResult<bool> Handle(int userId, IUpdateByAdminPasswordDto dto)
    {
        return _handle(userId, dto.Password, "", true);
    }

    private ICustomResult<bool> _handle(
        int userId,
        string password,
        string oldPassword = "",
        bool skipOldPasswordCompare = false
    )
    {
        var result = new CustomResult<bool>();
        var entity = userPasswordRepository.FindByUserId(userId);

        if (entity != null && (!string.IsNullOrEmpty(oldPassword) || skipOldPasswordCompare))
        {
            if (skipOldPasswordCompare == false && BCrypt.Net.BCrypt.Verify(oldPassword, entity.Password) == false)
                return result.SetError(UserMessageErrors.DifferentPassword);

            entity.Password = BCrypt.Net.BCrypt.HashPassword(password);
            userPasswordRepository.Update(entity);
        }
        else
        {
            userPasswordRepository.Create(new UserPassword
            {
                UserId = userId,
                Password = BCrypt.Net.BCrypt.HashPassword(password)
            });
        }

        result.Data = true;
        return result;
    }
}