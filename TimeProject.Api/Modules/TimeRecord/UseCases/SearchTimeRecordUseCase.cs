using TimeProject.Core.Application.General;
using TimeProject.Core.Domain.Repositories;
using TimeProject.Core.Domain.UseCases.TimeRecord;

namespace TimeProject.Api.Modules.TimeRecord.UseCases;

public class SearchTimeRecordUseCase(ITimeRecordRepository repo) : ISearchTimeRecordUseCase
{
    public async Task<Result<List<SearchTimeRecordItem>>> Handle(string search, int userId)
    {
        var result = new Result<List<SearchTimeRecordItem>>();
        return result.SetData(await repo.SearchTimeRecord(search, userId));
    }
}