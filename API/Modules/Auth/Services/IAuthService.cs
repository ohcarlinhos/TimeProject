using API.Modules.Auth.Models;
using API.Modules.Shared;

namespace API.Modules.Auth.Services;

public interface IAuthService
{
    Task<Result<object>> Login(LoginDto dto);
}