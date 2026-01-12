using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Infrastructure.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Records;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.Records;

public class DeleteRecordUseCase(IRecordRepository repo) : IDeleteRecordUseCase
{
    public ICustomResult<bool> Handle(int id, int userId)
    {
        var result = new CustomResult<bool>();
        var entity = repo.FindById(id, userId);

        return entity == null
            ? result.SetError(TimeRecordMessageErrors.NotFound)
            : result.SetData(repo.Delete(entity));
    }
}