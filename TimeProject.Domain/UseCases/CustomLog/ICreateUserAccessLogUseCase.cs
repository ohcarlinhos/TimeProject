using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.CustomLog;

public interface ICreateUserAccessLogUseCase
{
    ICustomResult<IUserAccessLog> Handle(IUserAccessLog entity);
}