using API.Modules.User.Services.Config;
using Shared.General;
using Shared.User;

namespace API.Modules.User.Services;

public interface IUserServices
{
    Result<Pagination<UserMap>> Index(PaginationQuery paginationQuery);
    Task<Result<UserMap>> Create(CreateUserDto dto);
    Task<Result<UserMap>> Update(int id, UpdateUserDto dto);
    Task<Result<UserMap>> Update(int id, UpdateUserDto dto, UpdateUserMethodConfig config);
    Task<Result<UserMap>> UpdateRole(int id, UpdateRoleDto dto);
    Task<Result<bool>> Disable(int id, DisableUserDto dto);
    Task<Result<bool>> Delete(int id);
    Task<Result<UserMap>> Get(int id);
}