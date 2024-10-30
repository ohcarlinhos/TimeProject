using Core.User;
using Core.User.UseCases;
using Core.User.Utils;
using App.Infra.Errors;
using Entities;
using Shared.General;
using Shared.User;

namespace App.Modules.User.UseCases;

public class UpdateUserRoleUseCase(IUserRepository repo, IUserMapDataUtil mapper): IUpdateUserRoleUseCase
{
    public async Task<Result<UserMap>> Handle(int id, UpdateRoleDto dto)
    {
        var result = new Result<UserMap>();
        var user = await repo.FindById(id);

        if (user == null)
            return result.SetError(UserMessageErrors.NotFound);

        if (Enum.TryParse(typeof(UserRole), dto.Role, out var userRole) == false)
        {
            return result.SetError(UserMessageErrors.RoleNotFound);
        }

        user.UserRole = (UserRole)userRole;

        var entity = await repo.Update(user);
        result.Data = mapper.Handle(entity);
        return result;
    }
}