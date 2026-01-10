using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Api.Infrastructure.Interfaces;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.UseCases.CustomLog;
using TimeProject.Core.Domain.UseCases.Login;
using TimeProject.Core.Domain.UseCases.User;
using TimeProject.Core.RemoveDependencies.Dtos.Auth;
using TimeProject.Core.RemoveDependencies.General;
using TimeProject.Infrastructure.Interfaces;

namespace TimeProject.Application.UseCases.Auth;

public class LoginUseCase(
    IJwtHandler jwtHandler,
    IGetUserPasswordByEmailUseCase getUserPasswordByEmailUseCase,
    ICreateUserAccessLogUseCase createUserAccessLogUseCase
)
    : ILoginUseCase
{
    public async Task<Result<JwtResult>> Handle(LoginDto dto, UserAccessLogEntity ac)
    {
        var result = new Result<JwtResult>();

        var findUserPasswordResult = await getUserPasswordByEmailUseCase.Handle(dto.Email);
        if (findUserPasswordResult.HasError) return result.SetError(findUserPasswordResult.Message);

        var data = findUserPasswordResult.Data!;

        var passwordMatch = BCrypt.Net.BCrypt.Verify(dto.Password, data.UserPassword.Password);
        if (!passwordMatch) return result.SetError(AuthMessageErrors.WrongEmailOrPassword);

        ac.UserId = data.User.Id;
        await createUserAccessLogUseCase.Handle(ac);

        return result.SetData(jwtHandler.Generate(data.User));
    }
}