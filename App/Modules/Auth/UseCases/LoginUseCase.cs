using Core.User.UseCases;
using App.Infra.Errors;
using App.Infra.Interfaces;
using Core.Auth.UseCases;
using Entities;
using Shared.Auth;
using Shared.General;

namespace App.Modules.Auth.UseCases;

public class LoginUseCase(ITokenService tokenService, IGetUserByEmailUseCase getUserByEmailUseCase) : ILoginUseCase
{
    public Task<Result<JwtData>> Handle(LoginDto dto)
    {
        return Handle(dto, false);
    }

    public Task<Result<JwtData>> Handle(LoginDto dto, bool onlyAdmin)
    {
        return _login(dto, onlyAdmin);
    }

    private async Task<Result<JwtData>> _login(LoginDto dto, bool onlyAdmin = false)
    {
        var result = new Result<JwtData>();

        var findUserResult = await getUserByEmailUseCase.Handle(dto.Email);
        if (findUserResult.HasError) return result.SetError(AuthMessageErrors.WrongEmailOrPassword);

        var user = findUserResult.Data!;

        if (onlyAdmin && user.UserRole != UserRole.Admin)
        {
            return result.SetError(GeneralMessageErrors.Forbidden);
        }

        if (BCrypt.Net.BCrypt.Verify(dto.Password, user.Password) == false)
        {
            return result.SetError(AuthMessageErrors.WrongEmailOrPassword);
        }

        return result.SetData(tokenService.GenerateBearerJwt(user));
    }
}