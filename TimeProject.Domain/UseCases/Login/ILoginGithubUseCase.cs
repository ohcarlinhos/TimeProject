using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.Auth;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.Login;

public interface ILoginGithubUseCase
{
    Task<Result<JwtResult>> Handle(LoginGithubDto dto, UserAccessLogEntity ac);
}