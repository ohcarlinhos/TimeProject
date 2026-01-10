using TimeProject.Core.RemoveDependencies.Dtos.Auth;
using TimeProject.Core.RemoveDependencies.General;
using TimeProject.Core.Domain.Entities;

namespace TimeProject.Core.Domain.UseCases.Login;

public interface ILoginGoogleUseCase
{
    Task<Result<JwtDto>> Handle(LoginGoogleDto dto, UserAccessLogEntity ac);
}