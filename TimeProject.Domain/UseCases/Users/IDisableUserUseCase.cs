using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Users;

public interface IDisableUserUseCase
{
    ICustomResult<bool> Handle(int id, IDisableUserDto dto);
}