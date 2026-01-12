using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.Dtos.Auths;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Logins;

public interface ILoginGoogleUseCase
{
    Task<ICustomResult<IJwtResult>> Handle(ILoginGoogleDto dto, IUserAccessLog ac);
}