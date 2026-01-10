using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.TimeRecord;

public interface IGetTimeRecordByIdUseCase
{
    Task<Result<Entities.Record>> Handle(int id, int userId);
}