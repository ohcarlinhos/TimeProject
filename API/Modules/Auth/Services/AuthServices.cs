using API.Handlers.Email;
using API.Infrastructure.Services;
using API.Modules.Auth.Errors;
using API.Modules.User.Repositories;
using Entities;
using Shared.Auth;
using Shared.General;
using Shared.Handlers.Email;

namespace API.Modules.Auth.Services;

public class AuthServices(IUserRepository userRepository, ITokenService tokenService, IEmailHandler emailHandler)
    : IAuthService
{
    public async Task<Result<JwtData>> Login(LoginDto dto)
    {
        return await Login(dto, false);
    }

    public async Task<Result<JwtData>> Login(LoginDto dto, bool onlyAdmin)
    {
        return await _login(dto, onlyAdmin);
    }

    public async Task<Result<bool>> Recovery(RecoveryDto recoveryDto)
    {
        var result = new Result<bool>();

        try
        {
            if (await userRepository.FindByEmail(recoveryDto.Email) != null)
                emailHandler.Send(new EmailPayload
                {
                    To = recoveryDto.Email,
                    Body = @"TODO: implement recovery email"
                });

            result.Data = true;
        }
        catch
        {
            return result.SetError("send_recovery_email_error");
        }

        return result;
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