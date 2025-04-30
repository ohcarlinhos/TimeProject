using Entities;
using Shared.Auth;
using Shared.General;

namespace Core.Auth.UseCases;

public interface ILoginGithubUseCase
{
    Task<Result<JwtData>> Handle(LoginGithubDto dto, UserAccessLogEntity ac);
}