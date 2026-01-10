using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.Auth;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Login;

public interface ILoginUseCase
{
    Task<ICustomResult<JwtResult>> Handle(LoginDto dto, UserAccessLog ac);
}