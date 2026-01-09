using TimeProject.Core.Application.Dtos.User;
using TimeProject.Core.Application.General;

namespace TimeProject.Core.Domain.UseCases.User;

public interface IUpdateUserRoleUseCase
{
    Task<Result<UserOutDto>> Handle(int id, UpdateRoleDto dto);
}