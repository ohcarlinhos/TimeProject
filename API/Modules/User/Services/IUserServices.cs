using API.Modules.Shared;
using Shared;
using Shared.General;
using Shared.User;

namespace API.Modules.User.Services;

public interface IUserServices
{
    Result<Pagination<UserMap>> Index(PaginationQuery paginationQuery);
    Task<Result<UserMap>> Create(CreateUserDto dto);
    Task<Result<UserMap>> Update(int id, UpdateUserDto dto);
    Task<Result<bool>> Disable(int id);
    Task<Result<bool>> Delete(int id);
    Task<Result<UserMap>> Get(int id);
}