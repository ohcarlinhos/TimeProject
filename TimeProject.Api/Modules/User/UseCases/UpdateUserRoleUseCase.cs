using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Core.Application.Dtos.User;
using TimeProject.Core.Application.General;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.Repositories;
using TimeProject.Core.Domain.UseCases.User;
using TimeProject.Core.Domain.Utils;

namespace TimeProject.Api.Modules.User.UseCases;

public class UpdateUserRoleUseCase(IUserRepository repo, IUserMapDataUtil mapper) : IUpdateUserRoleUseCase
{
    public async Task<Result<UserOutDto>> Handle(int id, UpdateRoleDto dto)
    {
        var result = new Result<UserOutDto>();
        var user = await repo.FindById(id);

        if (user == null)
            return result.SetError(UserMessageErrors.NotFound);

        if (Enum.TryParse(typeof(UserRole), dto.Role, out var userRole) == false)
            return result.SetError(UserMessageErrors.RoleNotFound);

        user.UserRole = (UserRole)userRole;

        var entity = await repo.Update(user);
        result.Data = mapper.Handle(entity);
        return result;
    }
}