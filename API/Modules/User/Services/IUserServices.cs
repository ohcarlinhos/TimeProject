using API.Modules.Shared;
using API.Modules.User.Dto;
using API.Modules.User.Map;

namespace API.Modules.User.Services;

public interface IUserServices
{
    Task<Result<UserMap>> Create(CreateUserDto dto);
    Task<Result<UserMap>> Update(int id, UpdateUserDto dto);
    Task<Result<bool>> Delete(int id);
    Task<Result<UserMap>> Get(int id);
}