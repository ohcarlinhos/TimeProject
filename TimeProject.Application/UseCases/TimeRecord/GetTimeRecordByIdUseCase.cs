using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.TimeRecord;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.TimeRecord;

public class GetTimeRecordByIdUseCase(IRecordRepository repo) : IGetTimeRecordByIdUseCase
{
    public async Task<ICustomResult<Record>> Handle(int id, int userId)
    {
        var result = new CustomResult<Record>();
        var entity = await repo.FindById(id, userId);

        return entity == null
            ? result.SetError(TimeRecordMessageErrors.NotFound)
            : result.SetData(entity);
    }
}