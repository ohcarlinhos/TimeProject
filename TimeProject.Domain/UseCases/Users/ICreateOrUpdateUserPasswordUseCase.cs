using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Users;

public interface ICreateOrUpdateUserPasswordUseCase
{
    public ICustomResult<bool> Handle(int userId, ICreatePasswordDto dto);
    public ICustomResult<bool> Handle(int userId, IUpdatePasswordDto dto);
    public ICustomResult<bool> Handle(int userId, IUpdateByAdminPasswordDto dto);
}