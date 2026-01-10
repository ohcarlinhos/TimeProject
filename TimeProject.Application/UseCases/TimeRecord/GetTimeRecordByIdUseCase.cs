using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.TimeRecord;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Application.UseCases.TimeRecord;

public class GetTimeRecordByIdUseCase(ITimeRecordRepository repo) : IGetTimeRecordByIdUseCase
{
    public async Task<Result<Domain.Entities.Record>> Handle(int id, int userId)
    {
        var result = new Result<Domain.Entities.Record>();
        var entity = await repo.FindById(id, userId);

        return entity == null
            ? result.SetError(TimeRecordMessageErrors.NotFound)
            : result.SetData(entity);
    }
}