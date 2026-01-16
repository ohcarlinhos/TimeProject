using TimeProject.Infrastructure.ObjectValues;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Dtos.Periods;
using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Periods;
using TimeProject.Domain.UseCases.Records;
using TimeProject.Infrastructure.Utils.Interfaces;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.Errors;
using TimeProject.Infrastructure.ObjectValues.Records;

namespace TimeProject.Application.UseCases.Periods;

public class UpdatePeriodUseCase(
    IPeriodRepository repository,
    ISyncRecordMetaUseCase syncRecordMetaUseCase,
    IPeriodValidateUtil periodValidateUtil
) : IUpdatePeriodUseCase
{
    public ICustomResult<IPeriod> Handle(int id, IPeriodData data, int userId)
    {
        var result = new CustomResult<IPeriod>();

        periodValidateUtil.ValidateStartAndEnd(data.Start, data.End, result);
        if (result.HasError) return result;

        var period = repository.FindById(id, userId);
        if (period == null) return result.SetError(PeriodMessageErrors.NotFound);

        period.Start = data.Start;
        period.End = data.End;

        repository.Update(period);
        
        if (period.RecordId != null)
            syncRecordMetaUseCase.Handle((int)period.RecordId);

        return result.SetData(period);
    }
}