using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Infrastructure.ObjectValues.Pagination;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Records;
using TimeProject.Domain.UseCases.Sessions;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Infrastructure.Errors;

namespace TimeProject.Application.UseCases.Sessions;

public class DeleteSessionUseCase(
    ISessionRepository repository,
    IPeriodRepository periodRepository,
    ISyncRecordMetaUseCase syncRecordMetaUseCase) : IDeleteSessionUseCase
{
    public ICustomResult<bool> Handle(int id, int userId)
    {
        var result = new CustomResult<bool>();
        var entity = (Session)repository.FindById(id, userId);

        if (entity == null)
            return result.SetError(SessionMessageErrors.NotFound);

        periodRepository.DeleteByList(entity.PeriodRecords as IList<IPeriod>);
        var recordId = entity.RecordId;

        repository.Delete(entity);
        syncRecordMetaUseCase.Handle(recordId);

        return result.SetData(true);
    }
}