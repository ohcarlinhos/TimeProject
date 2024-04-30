using API.Modules.Shared;
using API.Modules.User.DTO;
using API.Modules.User.Models;

namespace API.Modules.User.Services;

public interface IUserServices
{
    Task<Result<UserDto>> Create(CreateUserModel model);
    Task<Result<UserDto>> Update(int id, UpdateUserModel model);
    Task<Result<bool>> Delete(int id);
    Task<Result<UserDto>> Get(int id);
}