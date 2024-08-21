using API.Modules.Shared;
using Shared;
using Shared.Auth;
using Shared.General;

namespace API.Modules.Auth.Services;

public interface IAuthService
{
    Task<Result<JwtData>> Login(LoginDto dto);
    Task<Result<JwtData>> Login(LoginDto dto, bool onlyAdmin);
}