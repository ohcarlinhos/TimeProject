using API.Modules.Shared;
using Shared;
using Shared.Auth;

namespace API.Modules.Auth.Services;

public interface IAuthService
{
    Task<Result<object>> Login(LoginDto dto);
}