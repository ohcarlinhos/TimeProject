using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.Auth;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.Login;

public interface ILoginUseCase
{
    Task<Result<JwtResult>> Handle(LoginDto dto, UserAccessLogEntity ac);
}