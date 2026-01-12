using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Records;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.Records;

public class GetRecordByIdUseCase(IRecordRepository repo) : IGetRecordByIdUseCase
{
    public ICustomResult<IRecord> Handle(int id, int userId)
    {
        var result = new CustomResult<IRecord>();
        var entity = repo.FindById(id, userId);

        return entity == null
            ? result.SetError(TimeRecordMessageErrors.NotFound)
            : result.SetData(entity);
    }
}