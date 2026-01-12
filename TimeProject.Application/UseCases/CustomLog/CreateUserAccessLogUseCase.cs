using TimeProject.Infrastructure.ObjectValues;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.CustomLogs;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.CustomLog;

public class CreateUserAccessLogUseCase(IUserAccessLogRepository repository) : ICreateUserAccessLogUseCase
{
    public ICustomResult<IUserAccessLog> Handle(IUserAccessLog entity)
    {
        return new CustomResult<IUserAccessLog>().SetData(repository.Create(entity));
    }
}