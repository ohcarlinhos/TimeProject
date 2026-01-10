using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Api.Infrastructure.Interfaces;
using TimeProject.Domain.Entities;
using TimeProject.Domain.UseCases.CustomLog;
using TimeProject.Domain.UseCases.Login;
using TimeProject.Domain.UseCases.User;
using TimeProject.Domain.RemoveDependencies.Dtos.Auth;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.Interfaces;

namespace TimeProject.Application.UseCases.Auth;

public class LoginUseCase(
    IJwtHandler jwtHandler,
    IGetUserPasswordByEmailUseCase getUserPasswordByEmailUseCase,
    ICreateUserAccessLogUseCase createUserAccessLogUseCase
)
    : ILoginUseCase
{
    public async Task<ICustomResult<JwtResult>> Handle(LoginDto dto, UserAccessLog ac)
    {
        var result = new CustomResult<JwtResult>();

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