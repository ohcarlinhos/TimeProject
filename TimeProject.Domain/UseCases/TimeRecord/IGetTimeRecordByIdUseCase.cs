using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.TimeRecord;

public interface IGetTimeRecordByIdUseCase
{
    Task<ICustomResult<Record>> Handle(int id, int userId);
}