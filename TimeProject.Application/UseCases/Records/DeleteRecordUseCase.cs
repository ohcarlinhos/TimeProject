using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Infrastructure.ObjectValues.Pagination;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Records;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.Records;

public class DeleteRecordUseCase(IRecordRepository repository) : IDeleteRecordUseCase
{
    public ICustomResult<bool> Handle(int id, int userId)
    {
        var result = new CustomResult<bool>();
        var entity = repository.FindById(id, userId);

        return entity == null
            ? result.SetError(RecordMessageErrors.NotFound)
            : result.SetData(repository.Delete(entity));
    }
}