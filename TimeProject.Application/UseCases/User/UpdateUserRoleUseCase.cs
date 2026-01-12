using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Infrastructure.ObjectValues;
using TimeProject.Infrastructure.Entities.Enums;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Users;
using TimeProject.Infrastructure.Utils.Interfaces;
using TimeProject.Domain.Dtos.Users;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.User;

public class UpdateUserRoleUseCase(IUserRepository repo, IUserMapDataUtil mapper) : IUpdateUserRoleUseCase
{
    public ICustomResult<IUserOutDto> Handle(int id, IUpdateRoleDto dto)
    {
        var result = new CustomResult<IUserOutDto>();
        var user = repo.FindById(id);

        if (user == null)
            return result.SetError(UserMessageErrors.NotFound);

        if (Enum.TryParse(typeof(UserRoleType), dto.Role, out var userRole) == false)
            return result.SetError(UserMessageErrors.RoleNotFound);

        user.UserRole = (UserRoleType)userRole;

        var entity = repo.Update(user);
        result.Data = mapper.Handle(entity);
        return result;
    }
}