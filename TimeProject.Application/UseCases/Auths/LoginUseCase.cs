using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Infrastructure.ObjectValues;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.UseCases.CustomLogs;
using TimeProject.Domain.UseCases.Logins;
using TimeProject.Domain.UseCases.Users;
using TimeProject.Domain.Dtos.Auths;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.Interfaces;

namespace TimeProject.Application.UseCases.Auths;

public class LoginUseCase(
    IJwtHandler jwtHandler,
    IGetUserPasswordByEmailUseCase getUserPasswordByEmailUseCase,
    ICreateUserAccessLogUseCase createUserAccessLogUseCase
)
    : ILoginUseCase
{
    public ICustomResult<IJwtResult> Handle(ILoginDto dto, IUserAccessLog ac)
    {
        var result = new CustomResult<IJwtResult>();

        var findUserPasswordResult = getUserPasswordByEmailUseCase.Handle(dto.Email);
        if (findUserPasswordResult.HasError) return result.SetError(findUserPasswordResult.Message);

        var data = findUserPasswordResult.Data!;

        var passwordMatch = BCrypt.Net.BCrypt.Verify(dto.Password, data.UserPassword.Password);
        if (!passwordMatch) return result.SetError(AuthMessageErrors.WrongEmailOrPassword);

        ac.UserId = data.User.Id;
        createUserAccessLogUseCase.Handle(ac);

        return result.SetData(jwtHandler.Generate(data.User));
    }
}