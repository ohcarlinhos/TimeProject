using Entities;
using Shared.Auth;
using Shared.General;

namespace Core.Auth.UseCases;

public interface ILoginGoogleUseCase
{
    Task<Result<JwtData>> Handle(LoginGoogleDto dto, UserAccessLogEntity ac);
}