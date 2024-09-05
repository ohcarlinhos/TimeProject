using API.Infrastructure.Services;
using API.Modules.Auth.Errors;
using API.Modules.User.Repositories;
using Entities;
using Shared.Auth;
using Shared.General;

namespace API.Modules.Auth.Services;

public class AuthServices(IUserRepository userRepository, ITokenService tokenService) : IAuthService
{
    public async Task<Result<JwtData>> Login(LoginDto dto)
    {
        return await Login(dto, false);
    }

    public async Task<Result<JwtData>> Login(LoginDto dto, bool onlyAdmin)
    {
        return await _login(dto, onlyAdmin);
    }

    private async Task<Result<JwtData>> _login(LoginDto dto, bool onlyAdmin = false)
    {
        var result = new Result<JwtData>();
        var user = await userRepository.FindByEmail(dto.Email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
        {
            result.Message = AuthErrors.WrongEmailOrPassword;
            result.HasError = true;
            return result;
        }

        if (onlyAdmin && user.UserRole != UserRole.Admin)
        {
            return result.SetError("forbid");
        }

        result.Data = tokenService.GenerateBearerJwt(user);
        return result;
    }
}