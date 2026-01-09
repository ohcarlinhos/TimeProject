using TimeProject.Core.Application.Dtos.Auth;
using TimeProject.Core.Application.General;
using TimeProject.Core.Domain.Entities;

namespace TimeProject.Core.Domain.UseCases.Login;

public interface ILoginUseCase
{
    Task<Result<JwtDto>> Handle(LoginDto dto, UserAccessLogEntity ac);
}