using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.Auth;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Login;

public interface ILoginGoogleUseCase
{
    Task<ICustomResult<JwtResult>> Handle(LoginGoogleDto dto, IUserAccessLog ac);
}