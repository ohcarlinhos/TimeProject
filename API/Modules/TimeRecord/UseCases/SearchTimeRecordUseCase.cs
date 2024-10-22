using API.Core.TimeRecord;
using API.Core.TimeRecord.Repositories;
using API.Core.TimeRecord.UseCases;
using Shared.General;

namespace API.Modules.TimeRecord.UseCases;

public class SearchTimeRecordUseCase(ITimeRecordRepository repo) : ISearchTimeRecordUseCase
{
    public async Task<Result<List<SearchTimeRecordItem>>> Handle(string search, int userId)
    {
        var result = new Result<List<SearchTimeRecordItem>>();
        return result.SetData(await repo.SearchTimeRecord(search, userId));
    }
}