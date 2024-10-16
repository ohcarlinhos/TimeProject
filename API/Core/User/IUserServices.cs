using API.Modules.User.Services.Config;
using Entities;
using Shared.General;
using Shared.General.Pagination;
using Shared.User;

namespace API.Core.User;

public interface IUserServices
{
    Result<Pagination<UserMap>> Index(PaginationQuery paginationQuery);
    Task<Result<UserMap>> Update(int id, UpdateUserDto dto);
    Task<Result<UserMap>> Update(int id, UpdateUserDto dto, UpdateUserMethodConfig config);
    Task<Result<UserMap>> UpdateRole(int id, UpdateRoleDto dto);
    Task<Result<UserMap>> UpdatePasswordByEmail(string email, string password);
    Task<Result<bool>> Disable(int id, DisableUserDto dto);
    Task<Result<bool>> Delete(int id);
    Task<Result<UserMap>> Details(int id);
    Task<Result<UserEntity>> FindById(int id);
    Task<Result<UserEntity>> FindByEmail(string email);
}