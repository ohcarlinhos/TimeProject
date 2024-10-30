using Shared.General;

namespace Core.TimeRecord.UseCases;

public interface ISearchTimeRecordUseCase
{
    Task<Result<List<SearchTimeRecordItem>>> Handle(string search, int userId);
}