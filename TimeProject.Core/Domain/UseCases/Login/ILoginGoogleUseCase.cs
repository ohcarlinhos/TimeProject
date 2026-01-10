using TimeProject.Core.Domain.Entities;
using TimeProject.Core.RemoveDependencies.Dtos.Auth;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Core.Domain.UseCases.Login;

public interface ILoginGoogleUseCase
{
    Task<Result<JwtResult>> Handle(LoginGoogleDto dto, UserAccessLogEntity ac);
}