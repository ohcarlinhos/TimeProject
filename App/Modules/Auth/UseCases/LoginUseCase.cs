using Core.User.UseCases;
using App.Infrastructure.Errors;
using App.Infrastructure.Interfaces;
using Core.Auth.UseCases;
using Shared.Auth;
using Shared.General;

namespace App.Modules.Auth.UseCases;

public class LoginUseCase(IJwtService jwtService, IGetUserPasswordByEmailUseCase getUserPasswordByEmailUseCase)
    : ILoginUseCase
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

        var findUserPasswordResult = await getUserPasswordByEmailUseCase.Handle(dto.Email);
        if (findUserPasswordResult.HasError)
        {
            return result.SetError(findUserPasswordResult.Message);
        }

        var data = findUserPasswordResult.Data!;

        return BCrypt.Net.BCrypt.Verify(dto.Password, data.UserPassword.Password)
            ? result.SetData(jwtService.Generate(data.User))
            : result.SetError(AuthMessageErrors.WrongEmailOrPassword);
    }
}