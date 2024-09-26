using Shared.Auth;
using Shared.General;

namespace API.Modules.Auth.Services;

public interface IAuthService
{
    Task<Result<JwtData>> Login(LoginDto dto);
    Task<Result<JwtData>> Login(LoginDto dto, bool onlyAdmin);
    Task<Result<bool>> Recovery(RecoveryDto dto);
    Task<Result<bool>> RecoveryPassword(RecoveryPasswordDto dto);
}