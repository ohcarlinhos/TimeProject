using TimeProject.Core.Application.Dtos.Auth;
using TimeProject.Core.Application.General;
using TimeProject.Core.Domain.Entities;

namespace TimeProject.Core.Domain.UseCases.Login;

public interface ILoginGoogleUseCase
{
    Task<Result<JwtDto>> Handle(LoginGoogleDto dto, UserAccessLogEntity ac);
}