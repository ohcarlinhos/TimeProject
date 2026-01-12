using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Users;

public interface IUpdateUserRoleUseCase
{
    ICustomResult<IUserOutDto> Handle(int id, IUpdateRoleDto dto);
}