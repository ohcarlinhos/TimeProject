using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.CustomLogs;

public interface ICreateUserAccessLogUseCase
{
    ICustomResult<IUserAccessLog> Handle(IUserAccessLog entity);
}