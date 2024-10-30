using Shared.General;
using Shared.User;

namespace Core.User.UseCases;

public interface IUpdateUserRoleUseCase
{
    Task<Result<UserMap>> Handle(int id, UpdateRoleDto dto);
}