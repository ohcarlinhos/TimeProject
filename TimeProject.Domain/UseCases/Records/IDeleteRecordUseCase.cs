using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Records;

public interface IDeleteRecordUseCase
{
    ICustomResult<bool> Handle(int id, int userId);
}