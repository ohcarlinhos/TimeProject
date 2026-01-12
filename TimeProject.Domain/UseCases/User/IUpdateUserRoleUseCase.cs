using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.User;

public interface IUpdateUserRoleUseCase
{
    ICustomResult<IUserOutDto> Handle(int id, IUpdateRoleDto dto);
}