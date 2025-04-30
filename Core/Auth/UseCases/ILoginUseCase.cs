using Entities;
using Shared.Auth;
using Shared.General;

namespace Core.Auth.UseCases;

public interface ILoginUseCase
{
    Task<Result<JwtData>> Handle(LoginDto dto, UserAccessLogEntity ac);
}