using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.User;
using TimeProject.Domain.Utils;
using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.User;

public class UpdateUserRoleUseCase(IUserRepository repo, IUserMapDataUtil mapper) : IUpdateUserRoleUseCase
{
    public async Task<ICustomResult<UserOutDto>> Handle(int id, UpdateRoleDto dto)
    {
        var result = new CustomResult<UserOutDto>();
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