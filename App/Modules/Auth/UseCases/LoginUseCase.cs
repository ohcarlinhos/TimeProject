using Core.User.UseCases;
using App.Infrastructure.Errors;
using App.Infrastructure.Interfaces;
using Core.Auth.UseCases;
using Core.Loogs.UserCases;
using Entities;
using Shared.Auth;
using Shared.General;

namespace App.Modules.Auth.UseCases;

public class LoginUseCase(
    IJwtService jwtService,
    IGetUserPasswordByEmailUseCase getUserPasswordByEmailUseCase,
    ICreateUserAccessLog createUserAccessLog
)
    : ILoginUseCase
{
    public async Task<Result<JwtData>> Handle(LoginDto dto, UserAccessLogEntity ac)
    {
        var result = new Result<JwtData>();

        var findUserPasswordResult = await getUserPasswordByEmailUseCase.Handle(dto.Email);
        if (findUserPasswordResult.HasError)
        {
            return result.SetError(findUserPasswordResult.Message);
        }

        var data = findUserPasswordResult.Data!;

        var passwordMatch = BCrypt.Net.BCrypt.Verify(dto.Password, data.UserPassword.Password);
        if (!passwordMatch)
        {
            return result.SetError(AuthMessageErrors.WrongEmailOrPassword);
        }

        ac.UserId = data.User.Id;
        await createUserAccessLog.Handle(ac);

        return result.SetData(jwtService.Generate(data.User));
    }
}