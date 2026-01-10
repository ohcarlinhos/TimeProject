using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.Auth;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.Login;

public interface ILoginGoogleUseCase
{
    Task<Result<JwtResult>> Handle(LoginGoogleDto dto, UserAccessLogEntity ac);
}