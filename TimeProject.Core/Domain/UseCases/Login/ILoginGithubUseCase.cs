using TimeProject.Core.Domain.Entities;
using TimeProject.Core.RemoveDependencies.Dtos.Auth;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Core.Domain.UseCases.Login;

public interface ILoginGithubUseCase
{
    Task<Result<JwtResult>> Handle(LoginGithubDto dto, UserAccessLogEntity ac);
}