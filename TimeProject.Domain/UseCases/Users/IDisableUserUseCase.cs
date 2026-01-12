using TimeProject.Domain.Dtos.Users;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Users;

public interface IDisableUserUseCase
{
    ICustomResult<bool> Handle(int id, IDisableUserDto dto);
}