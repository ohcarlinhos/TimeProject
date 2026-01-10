using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.User;

public interface IUpdateUserRoleUseCase
{
    Task<Result<UserOutDto>> Handle(int id, UpdateRoleDto dto);
}