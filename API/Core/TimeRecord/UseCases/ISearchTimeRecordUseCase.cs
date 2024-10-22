using Shared.General;

namespace API.Core.TimeRecord.UseCases;

public interface ISearchTimeRecordUseCase
{
    Task<Result<List<SearchTimeRecordItem>>> Handle(string search, int userId);
}